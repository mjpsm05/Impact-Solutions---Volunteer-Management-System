using Microsoft.AspNetCore.Mvc;

namespace volunteer_management.Controllers;

public class AccountController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}