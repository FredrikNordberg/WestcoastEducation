using Microsoft.AspNetCore.Mvc;

namespace westcoast_education.web.Controllers
{
    [Route("users")]
    public class UsersAdminController : Controller
    {
       

        public IActionResult Index()
        {
            return View("Index");
        }

        
    }
}