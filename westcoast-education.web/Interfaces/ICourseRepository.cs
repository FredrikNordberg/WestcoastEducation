using westcoast_education.web.Models;

namespace westcoast_education.web.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
       Task<Course?> FindByCourseNumberAsync(string courseNum); 
      
    }
}