using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Data;
using westcoast_education.web.Models;

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

        public async Task<IActionResult> Index()
        {
            var courses = await _context.Courses.ToListAsync();
            return View("Index", courses);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            var course = new Course();
            return View("Create", course);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}