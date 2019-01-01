using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentRazorPage.Model;

namespace StudentRazorPage.Pages.StudentList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [TempData]
        public string Message { get; set; }

        public IEnumerable<Student> students { get; set; }// list of student from data base


        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            students = await _db.students.ToListAsync(); //IEnumerable<Student> students from database
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var st = await _db.students.FindAsync(id);
            _db.students.Remove(st);
            await _db.SaveChangesAsync();

            Message = "student deleted successully.";

            return RedirectToPage("Index");
        }
    }
}