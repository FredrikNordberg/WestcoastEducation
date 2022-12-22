using Microsoft.AspNetCore.Mvc;


namespace westcoast_education.web.Controllers;

public class HomeController : Controller
{

    // Action method.. namn index
    public IActionResult Index()
    {   
        ViewBag.Message = "Våra kurser!";
        // Returnerar ett ViewResult..
        return View("index");
    }
}
