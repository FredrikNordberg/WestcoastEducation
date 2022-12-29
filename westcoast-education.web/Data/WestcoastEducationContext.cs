using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Models;

namespace westcoast_education.web.Data
{
    public class WestcoastEducationContext: DbContext
    {
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Course> Courses => Set<Course>();
        public WestcoastEducationContext(DbContextOptions options) : base(options)
        {
        }

        
        
    }
}