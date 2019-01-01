using Microsoft.EntityFrameworkCore;

namespace StudentRazorPage.Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){

        }
        public DbSet<Student> students {get;set;} //add book table to database
    }
}