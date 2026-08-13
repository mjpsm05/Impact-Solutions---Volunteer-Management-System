using Microsoft.AspNetCore.Mvc;
using volunteer_management.Data;
using volunteer_management.Models;

namespace volunteer_management.Controllers;


public class OpportunityController(ApplicationDbContext context, ILogger<OpportunityController> logger)
    : Controller
{
    private readonly ILogger<OpportunityController> _logger = logger;
    
    private readonly ApplicationDbContext _context = context;

    public IActionResult Opportunities()
    {
        var allOpportunities = _context.Opportunities.ToList();
        return View(allOpportunities);
    } 
    public IActionResult Create()
    {
        return View();
    }

    public IActionResult CreateEditForm(Opportunity opportunity)
    {
        _context.Opportunities.Add(opportunity);
        
        _context.SaveChanges();
        
        return RedirectToAction("Opportunities");
    }
    
    public IActionResult Matches(int id)
    {
        return View();
    }
    
}
// "Project AI Use" Item 1 -  This code was written in collaboration with OpenAI. (2025). ChatGPT [Large language model]. https://chatgpt.com/