using Microsoft.AspNetCore.Mvc;


namespace westcoast_education.web.Controllers
{
    [Route("courses")]
    public class CoursesController : Controller
    {
      

        public IActionResult Index()
        {
            ViewBag.Courses = new List<string> {
                "Systemutveckling",
                "Webbutveckling",
                "Applikationsutveckling"
            };
            return View();
        }

       
    }
}