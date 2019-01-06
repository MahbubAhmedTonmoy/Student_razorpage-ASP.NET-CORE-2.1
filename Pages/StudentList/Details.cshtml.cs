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
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DetailsModel(ApplicationDbContext db){
            _db = db;
        }

        [BindProperty]
        public Student Student{get;set;}

        public void OnGet(int id)
        {
            Student = _db.students.Find(id);
        }

    }
}