using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentRazorPage.Model;

namespace StudentRazorPage.Pages.StudentList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db){
            _db = db;
        }

        [BindProperty]
        public Student Student{get;set;}

        public void OnGet(int id)
        {
            Student = _db.students.Find(id);
        }

        [TempData]
        public string Message { get; set; }

       public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var stdFromDb = _db.students.Find(Student.Id); // find student object from database
                stdFromDb.Name = Student.Name;
                stdFromDb.Class = Student.Class;
                stdFromDb.address = Student.address;
                stdFromDb.PhoneNumber = Student.PhoneNumber;
                
                await _db.SaveChangesAsync();
                Message = "Student information has been updated successfully";

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}