using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Models;

namespace westcoast_education.web.Data
{
    public class WestcoastEducationContext: DbContext
    {
        
        public DbSet<Course> Courses => Set<Course>();
        public WestcoastEducationContext(DbContextOptions options) : base(options)
        {
        }

        
        
    }
}