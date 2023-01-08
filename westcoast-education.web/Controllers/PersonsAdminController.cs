using Microsoft.AspNetCore.Mvc;
using westcoast_education.web.Interfaces;
using westcoast_education.web.Models;
using westcoast_education.web.ViewModels.Persons;


namespace westcoast_education.web.Controllers
{
    [Route("personsadmin")]
    public class PersonsAdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonsAdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.PersonRepository.ListAllAsync();
            var persons = result.Select(p => new PersonsListViewModel
            {
                PersonId = p.PersonId,
                PersonUserName = p.PersonUserName,
                PersonTitle = p.PersonTitle,
                PersonName = p.PersonName,
                PersonLastName = p.PersonLastName,
                PersonEmail = p.PersonEmail,
                PersonPhone = p.PersonPhone

            }).ToList();


            return View("Index", persons);

        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            var person = new PersonPostViewModel();
            return View("Create", person);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(PersonPostViewModel person)
        {
            if (!ModelState.IsValid) return View("Create", person);
            
            if (await _unitOfWork.PersonRepository.FindByPersonEmailAsync(person.PersonEmail) is not null)
            {
                var error = new ErrorModel
                {
                    ErrorTitle = "Ett fel har inträffat när användaren skulle sparas!",
                    ErrorMessage = $"En person med Email {person.PersonEmail} finns redan i systemet"
                };
                return View("_Error", error);
            }



            var personToAdd = new Person
            {
                PersonUserName = person.PersonUserName,
                PersonTitle = person.PersonTitle,
                PersonName = person.PersonName,
                PersonLastName = person.PersonLastName,
                PersonEmail = person.PersonEmail,
                PersonPhone = person.PersonPhone,
                Password = person.Password
            };

            if (await _unitOfWork.PersonRepository.AddAsync(personToAdd))
            {
                if (await _unitOfWork.Complete())
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View("_Error", new ErrorModel { ErrorTitle = "Gick inte att spara användare", ErrorMessage = $"Ett fel inträffade när användare {person.PersonName} {person.PersonLastName} skulle sparas" });

        }



        [HttpGet("edit/{personId}")]
        public async Task<IActionResult> Edit(int personId)
        {
            var result = await _unitOfWork.PersonRepository.FindByIdAsync(personId);

        if (result is null)
            {
                return View("_Error", new ErrorModel { ErrorTitle = "Kunde inte hitta användare", ErrorMessage = $"Vi kunde inte hitta någon användare med id {personId}" });
            }

            var personToUpdate = new PersonUpdateViewModel
            {
                PersonId = result.PersonId,
                PersonUserName = result.PersonUserName,
                PersonTitle = result.PersonTitle,
                PersonName = result.PersonName,
                PersonLastName = result.PersonLastName,
                PersonEmail = result.PersonEmail,
                PersonPhone = result.PersonPhone,
            };

            return View("Edit", personToUpdate);
        }

        [HttpPost("edit/{personId}")]
        public async Task<IActionResult> Edit(int personId, PersonUpdateViewModel person)
        {
            try
            {
                if (!ModelState.IsValid) return View("Edit", person);

                var personToUpdate = await _unitOfWork.PersonRepository.FindByIdAsync(personId);

                if (personToUpdate is null)
                {
                    var notFoundError = new ErrorModel
                    {
                        ErrorTitle = "Användare saknas!",
                        ErrorMessage = $"Det gick inte att hitta användaren {person.PersonName} {person.PersonLastName}"
                    };

                    return View("_Error", notFoundError);
                }

                personToUpdate.PersonUserName  = person.PersonUserName;
                personToUpdate.PersonTitle  = person.PersonTitle;
                personToUpdate.PersonName  = person.PersonName;
                personToUpdate.PersonLastName  = person.PersonLastName;
                personToUpdate.PersonEmail  = person.PersonEmail;
                personToUpdate.PersonPhone  = person.PersonPhone;

                if (await _unitOfWork.PersonRepository.UpdateAsync(personToUpdate))
                {
                    if (await _unitOfWork.Complete())
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

                return View("_Error", new ErrorModel {ErrorTitle = "Ett fel inträffade", ErrorMessage = "något gick fel när användaren skulle uppdateras"});
            }
            catch (Exception ex)
            {
                return View("_Error", new ErrorModel { ErrorTitle = "Ett fel inträffat", ErrorMessage = ex.Message});
            }
        }
        
        
        [Route("delete/{personId}")]
        public async Task<IActionResult> Delete(int personId)
        {
            try
            {
                var personToDelete = await _unitOfWork.PersonRepository.FindByIdAsync(personId);

                if (personToDelete is null) return RedirectToAction(nameof(Index));

                if (await _unitOfWork.PersonRepository.DeleteAsync(personToDelete))
                {
                    if(await _unitOfWork.Complete())
                    {
                        return RedirectToAction(nameof(Index));
                    }
                        
                }
                
                return View("_Error", new ErrorModel {ErrorTitle = "Ett fel inträffade när användaren skulle tas bort", ErrorMessage = $"Ett fel inträffade när användare id {personId} skulle raderas"});

            }

            
            catch (Exception ex)
            {
                return View("_Error", new ErrorModel {ErrorTitle = "Ett fel har inträffat", ErrorMessage = ex.Message});
                
            }
        }
    }
}