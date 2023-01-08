using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Data;
using westcoast_education.web.Interfaces;
using westcoast_education.web.Models;

namespace westcoast_education.web.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        
        public CourseRepository(WestcoastEducationContext context):base(context) { }

        public async Task<Course?> FindByCourseNumberAsync(string coursenumber)
    {
        return await _context.Courses.SingleOrDefaultAsync(c => c.CourseNumber.Trim().ToLower() == coursenumber.Trim().ToLower());
    }

    }
}