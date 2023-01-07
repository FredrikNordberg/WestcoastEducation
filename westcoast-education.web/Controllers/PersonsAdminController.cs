using Microsoft.AspNetCore.Mvc;
using westcoast_education.web.Interfaces;
using westcoast_education.web.Models;
using westcoast_education.web.ViewModels.Persons;


namespace westcoast_education.web.Controllers
{
    [Route("personsadmin")]
    public class PersonsAdminController : Controller
    {


        private readonly IPersonRepository _repo;

        public PersonsAdminController(IPersonRepository repo)
        {
            _repo = repo;

        }

        public async Task<IActionResult> Index()
        {
            var result = await _repo.ListAllAsync();
            var persons = result.Select(p => new PersonsListViewModel
            {
                PersonId = p.PersonId,
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

            if (await _repo.FindByIdAsync(person.PersonId) is not null)
            {
                var error = new ErrorModel
                {
                    ErrorTitle = "Ett fel har inträffat när användaren skulle sparas!",
                    ErrorMessage = $"En person med person id {person.PersonId} finns redan i systemet"
                };
                return View("_Error", error);
            }



            var personToAdd = new Person
            {
                PersonId = person.PersonId,
                PersonTitle = person.PersonTitle,
                PersonName = person.PersonName,
                PersonLastName = person.PersonLastName,
                PersonEmail = person.PersonEmail,
                PersonPhone = person.PersonPhone,
                Password = person.Password
            };

            if (await _repo.AddAsync(personToAdd))
            {
                if (await _repo.SaveAsync())
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View("_Error", new ErrorModel { ErrorTitle = "Gick inte att spara användare", ErrorMessage = $"Ett fel inträffade när användare {person.PersonName} {person.PersonLastName} skulle sparas" });

        }



        [HttpGet("edit/{personId}")]
        public async Task<IActionResult> Edit(int personId)
        {
            var result = await _repo.FindByIdAsync(personId);

        if (result is null)
            {
                return View("_Error", new ErrorModel { ErrorTitle = "Kunde inte hitta användare", ErrorMessage = $"Vi kunde inte hitta någon användare med id {personId}" });
            }

            var personToUpdate = new PersonUpdateViewModel
            {
                PersonId = result.PersonId,
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

                var personToUpdate = await _repo.FindByIdAsync(personId);

                if (personToUpdate is null)
                {
                    var notFoundError = new ErrorModel
                    {
                        ErrorTitle = "Användare saknas!",
                        ErrorMessage = $"Det gick inte att hitta användaren {person.PersonName} {person.PersonLastName}"
                    };

                    return View("_Error", notFoundError);
                }

                personToUpdate.PersonId  = person.PersonId;
                personToUpdate.PersonTitle  = person.PersonTitle;
                personToUpdate.PersonName  = person.PersonName;
                personToUpdate.PersonLastName  = person.PersonLastName;
                personToUpdate.PersonEmail  = person.PersonEmail;
                personToUpdate.PersonPhone  = person.PersonPhone;

                if (await _repo.UpdateAsync(personToUpdate))
                {
                    if (await _repo.SaveAsync())
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
                var personToDelete = await _repo.FindByIdAsync(personId);

                if (personToDelete is null) return RedirectToAction(nameof(Index));

                if (await _repo.DeleteAsync(personToDelete))
                {
                    if(await _repo.SaveAsync())
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