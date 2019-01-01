using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentRazorPage.Model;

namespace StudentRazorPage.Pages.StudentList
{
public class CreateModel : PageModel
    {
       // use dependency injection 
        private readonly ApplicationDbContext _db; //object of ApplicationDbCOntext cz access to database

        [TempData]
        public string Message { get; set; }

        // use dependency injection so create a constructor
        public CreateModel(ApplicationDbContext db) //ctor short form of constructor
        {
            _db = db;
        }

        [BindProperty] // or  public async Task<IActionResult> OnPost(Student Student)
        public Student Student { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost() // submit 
        {
            if (!ModelState.IsValid) //check Book model validation recquired 
            {
                return Page();
            }

            _db.students.Add(Student); 
            await _db.SaveChangesAsync();
            Message = "Student has been created successfully!";
            return RedirectToPage("Index");
        }
    }
}