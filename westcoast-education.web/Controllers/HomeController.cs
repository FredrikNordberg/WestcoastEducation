using Microsoft.AspNetCore.Mvc;


namespace westcoast_education.web.Controllers;

public class HomeController : Controller
{

    // Action method.. namn index
    public IActionResult Index()
    {   
        ViewBag.Message = "Vi har kurserna som passar dig!";
        // Returnerar ett ViewResult..
        return View("index");
    }
}
