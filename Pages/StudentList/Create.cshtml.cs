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
        
        private readonly ApplicationDbContext _db;

        [TempData]
        public string Message { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Student { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.students.Add(Student);
            await _db.SaveChangesAsync();
            Message = "Book has been created successfully!";
            return RedirectToPage("Index");
        }
    }
}