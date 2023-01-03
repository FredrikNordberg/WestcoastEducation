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
            try
            {
                var courses = await _context.Courses.ToListAsync();
                return View("Index", courses);
            }
            catch (Exception ex)
            {
                
                var error = new ErrorModel{
                    ErrorTitle = "Ett fel har inträffat när vi skulle hämta alla bilar",
                    ErrorMessage = ex.Message
                };

                return View("_Error", error);
            }
            
            
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
            try
            {
                var exists = await _context.Courses.SingleOrDefaultAsync(c => c.CourseId == course.CourseId);

            if (exists is not null)
            {
                var error = new ErrorModel
                {
                    ErrorTitle ="Ett fel har inträffat när kursen skulle sparas!",
                    ErrorMessage = $"En kurs med kursnummer {course.CourseId} finns redan i systemet"
                };

                return View("_Error", error);
            }

            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                
                var error = new ErrorModel{
                    ErrorTitle = "Ett fel har inträffat när vi skulle spara kursen",
                    ErrorMessage = ex.Message
                };

                return View("_Error", error);
            }
            

            
        }
         
         
          [HttpGet("edit/{courseId}")]
        public async Task<IActionResult> Edit(int courseId)
        {
            try
            {
                var course = await  _context.Courses.SingleOrDefaultAsync(c => c.CourseId == courseId);

            if (course is not null) return View("Edit", course);

            var error = new ErrorModel{
                ErrorTitle = "Ett fel har inträffat när vi skulle hämta en kurs för redegering",
                ErrorMessage = $"Vi hittar ingen kurs med id {courseId}"
            };

            return View("_Error", error);
            }
            catch (Exception ex)
            {
                
                var error = new ErrorModel{
                    ErrorTitle = "Ett fel har inträffat när vi hämtar kurs för redegering",
                    ErrorMessage = ex.Message
                };

                return View("_Error", error); 
            }
            
            
            
        }

        [HttpPost("edit/{courseId}")]
        public async Task<IActionResult> Edit(int courseId, Course course)
        {
            try
            {
                var courseToUpdate = _context.Courses.SingleOrDefault(c => c.CourseId == courseId);

                if(courseToUpdate is null) return RedirectToAction(nameof(Index));

                courseToUpdate.CourseId = course.CourseId;
                courseToUpdate.CourseName = course.CourseName;
                courseToUpdate.CourseLocation = course.CourseLocation;
                courseToUpdate.CourseLanguage = course.CourseLanguage;

                _context.Courses.Update(courseToUpdate);
                await _context.SaveChangesAsync();
            
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                
                 var error = new ErrorModel{
                    ErrorTitle = "Ett fel har inträffat när vi skulle spara kursen",
                    ErrorMessage = ex.Message
                };

                return View("_Error", error);
            }
            
        }

        [Route("delete/{courseId}")]
        public async Task<IActionResult> Delete(int courseId)
        {
            try
            {
                var courseToDelete = await _context.Courses.SingleOrDefaultAsync(c => c.CourseId == courseId);

                if(courseToDelete is null) return RedirectToAction(nameof(Index));

                _context.Courses.Remove(courseToDelete);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                
               var error = new ErrorModel{
                    ErrorTitle = "Ett fel har inträffat när kursen skulle raderas",
                    ErrorMessage = ex.Message
                };

                return View("_Error", error);
            }
            
        }

        
    }
}