using Microsoft.AspNetCore.Mvc;

namespace volunteer_management.Controllers;

public class VolunteerController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}