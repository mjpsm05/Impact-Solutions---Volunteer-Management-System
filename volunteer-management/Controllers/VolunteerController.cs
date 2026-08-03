using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using volunteer_management.Data;
using volunteer_management.Models;


namespace volunteer_management.Controllers;

public class VolunteerController : Controller
{

    //private readonly ApplicationDbContext _db;
    
    // Add database access
    /*public VolunteerController(ApplicationDbContext db)
    {
        _db = db;
    }*/
    
    // Default view
    public IActionResult Index()
    {
        //List<Volunteer> objVolunteerList = _db.Volunteers.ToList(); // Fetch db data when opening Volunteer page
        return View();
    }
    
    // Edit volunteer
    public IActionResult Edit()
    {
        return View();
    }
    
    // Add new volunteer
    public IActionResult Add()
    {
        return View();
    }
}