using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Data;
using westcoast_education.web.Interfaces;
using westcoast_education.web.Models;
using westcoast_education.web.ViewModels;

namespace westcoast_education.web.Controllers


{
    [Route("coursesadmin")]
    public class CoursesAdminController : Controller
    {
        
        
        private readonly IUnitOfWork _unitOfWork;

        public CoursesAdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                
                var courses = await _unitOfWork.CourseRepository.ListAllAsync();
                

                var model = courses.Select(v => new CourseListViewModel
                {
                    CourseId = v.CourseId,
                    CourseNumber = v.CourseNumber,
                    CourseName = v.CourseName,
                    CourseTitle = v.CourseTitle,
                    CourseStartDate = v.CourseStartDate,
                    CourseEndDate = v.CourseEndDate

                }).ToList();
                
                return View("Index", model);
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
            var course = new CoursePostViewModel();
            return View("Create", course);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CoursePostViewModel course)
        {
            try
            {
                if(!ModelState.IsValid) return View("Create", course);
                
            var exists = await _unitOfWork.CourseRepository.FindByCourseNumberAsync(course.CourseNumber);
            if (exists is not null)
            {
                var error = new ErrorModel
                {
                    ErrorTitle ="Ett fel har inträffat när kursen skulle sparas!",
                    ErrorMessage = $"En kurs med kursnummer {course.CourseNumber} finns redan i systemet"
                };

                return View("_Error", error);
            }

            var courseToAdd = new Course
            {
                CourseNumber = course.CourseNumber,
                CourseName = course.CourseName,
                CourseTitle = course.CourseTitle,
                CourseStartDate = course.CourseStartDate,
                CourseEndDate = course.CourseEndDate
            };

            

            if(await _unitOfWork.CourseRepository.AddAsync(courseToAdd))
            {
                if(await _unitOfWork.Complete())
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            var saveError = new ErrorModel
                {
                    ErrorTitle ="Ett fel har inträffat när kursen skulle sparas!",
                    ErrorMessage = $"Det inträffade ett fel när kursen med kursnummer {course.CourseNumber} skulle sparas"
                };

                return View("_Error", saveError);
            
            
            }
            catch (Exception ex)
            {
                
                var error = new ErrorModel
                {
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
                
                var result = await _unitOfWork.CourseRepository.FindByIdAsync(courseId);
                
                if (result is null){
                    var error = new ErrorModel
                    {
                        ErrorTitle = "Ett fel har inträffat när vi skulle hämta en kurs för redegering",
                        ErrorMessage = $"Vi hittar ingen kurs med id {courseId}"
                    };

                    return View("_Error", error);
               
                } 

                var model = new CourseUpdateViewModel
                {
                    CourseId = result.CourseId,
                    CourseNumber = result.CourseNumber,
                    CourseName = result.CourseName,
                    CourseTitle = result.CourseTitle,
                    CourseStartDate = result.CourseStartDate,
                    CourseEndDate = result.CourseEndDate

                };
                return View("Edit", model);

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
        public async Task<IActionResult> Edit(int courseId, CourseUpdateViewModel course)
        {
            try
            {
                if(!ModelState.IsValid) return View("Edit", course);

                // var courseToUpdate = _context.Courses.SingleOrDefault(c => c.CourseId == courseId);
                var courseToUpdate = await _unitOfWork.CourseRepository.FindByIdAsync(courseId);
                if(courseToUpdate is null) return RedirectToAction(nameof(Index));

                courseToUpdate.CourseNumber = course.CourseNumber;
                courseToUpdate.CourseName = course.CourseName;
                courseToUpdate.CourseTitle = course.CourseTitle;
                courseToUpdate.CourseStartDate = course.CourseStartDate;

                if(await _unitOfWork.CourseRepository.UpdateAsync(courseToUpdate)){
                    if(await _unitOfWork.Complete()){
                        return RedirectToAction(nameof(Index));
                    }
                }
                
                 var error = new ErrorModel
                {
                    ErrorTitle = "Ett fel har inträffat när vi skulle spara kursen",
                    ErrorMessage = $"Ett fel inträffade när vi skulle uppdatera bilen med kursnummer{courseToUpdate.CourseNumber}"
                };

                return View("_Error", error);
            }
            catch (Exception ex)
            {
                
                var error = new ErrorModel
                {
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
                
                var courseToDelete = await _unitOfWork.CourseRepository.FindByIdAsync(courseId);

                if(courseToDelete is null) return RedirectToAction(nameof(Index));

                
                if(await _unitOfWork.CourseRepository.DeleteAsync(courseToDelete))
                {
                    if(await _unitOfWork.Complete())
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                var error = new ErrorModel{
                    ErrorTitle = "Ett fel har inträffat när kursen skulle raderas",
                    ErrorMessage = $"Ett fel inträffade när kursen med kursnummer {courseToDelete.CourseNumber} skulle raderas"
                };

                return View("_Error", error);
                
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