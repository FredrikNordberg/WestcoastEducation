using Microsoft.AspNetCore.Mvc;
using westcoast_education.web.Data;

namespace westcoast_education.web.Controllers
{
    [Route("coursesadmin")]
    public class CoursesAdminController : Controller
    {
        private readonly WestcoastEducationContext _context;
        public CoursesAdminController(WestcoastEducationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        
    }
}