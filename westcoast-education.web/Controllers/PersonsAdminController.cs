using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Data;
using westcoast_education.web.Models;

namespace westcoast_education.web.Controllers
{
    [Route("personsadmin")]
    public class PersonsAdminController : Controller
    {
       

       private readonly WestcoastEducationContext _context;
        public PersonsAdminController(WestcoastEducationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var persons = await _context.Persons.ToListAsync();
                return View("Index", persons);
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
            var person = new Person();
            return View("Create", person);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Person person)
        {
            try
            {
                var exists = await _context.Persons.SingleOrDefaultAsync(c => c.PersonId == person.PersonId);

            if (exists is not null)
            {
                var error = new ErrorModel
                {
                    ErrorTitle ="Ett fel har inträffat när kursen skulle sparas!",
                    ErrorMessage = $"En kurs med kursnummer {person.PersonId} finns redan i systemet"
                };

                return View("_Error", error);
            }

            await _context.Persons.AddAsync(person);
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
         
         
          [HttpGet("edit/{personId}")]
        public async Task<IActionResult> Edit(int personId)
        {
            try
            {
                var person = await  _context.Persons.SingleOrDefaultAsync(c => c.PersonId == personId);

            if (person is not null) return View("Edit", person);

            var error = new ErrorModel{
                ErrorTitle = "Ett fel har inträffat när vi skulle hämta en kurs för redegering",
                ErrorMessage = $"Vi hittar ingen kurs med id {personId}"
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

        [HttpPost("edit/{personId}")]
        public async Task<IActionResult> Edit(int personId, Person person)
        {
            try
            {
                var personToUpdate = _context.Persons.SingleOrDefault(c => c.PersonId == personId);

                if(personToUpdate is null) return RedirectToAction(nameof(Index));

                personToUpdate.PersonId = person.PersonId;
                personToUpdate.PersonTitle = person.PersonTitle;
                personToUpdate.PersonName = person.PersonName;
                personToUpdate.PersonLastName = person.PersonLastName;
                personToUpdate.PersonEmail = person.PersonEmail;
                personToUpdate.PersonPhone = person.PersonPhone;

                _context.Persons.Update(personToUpdate);
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

        [Route("delete/{personId}")]
        public async Task<IActionResult> Delete(int personId)
        {
            try
            {
                var personToDelete = await _context.Persons.SingleOrDefaultAsync(c => c.PersonId == personId);

                if(personToDelete is null) return RedirectToAction(nameof(Index));

                _context.Persons.Remove(personToDelete);
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