using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using volunteer_management.Data;
using volunteer_management.Models;


namespace volunteer_management.Controllers;

public class VolunteerController : Controller
{

    private readonly ApplicationDbContext _db;
    
    // Add database access
    public VolunteerController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    // Display page to edit new volunteer
    public IActionResult Edit(int id)
    {
        // Pull volunteer by ID - Populate text fields accordingly 
        Volunteer? volunteerFromDb = _db.Volunteers.FirstOrDefault(v => v.Id == id);

        if (volunteerFromDb == null)
        {
            return NotFound();
        }
        
        return View(volunteerFromDb);
    }

    // VVV          AI-assisted code          VVV
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Volunteer volunteer)
    {
        if (id != volunteer.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _db.Volunteers.Update(volunteer);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Volunteers.Any(v => v.Id == volunteer.Id))
                {
                    return NotFound();
                }
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(volunteer);
    } // ^^^          End of AI-assisted code          ^^^
      // "Project AI Use" Item 3 -  This code was written in collaboration with Anthropic. (2026). Claude [Large language model]. https://claude.ai/
    
    // Display page to add new volunteer 
    public IActionResult Add()
    {
        return View();
    }
    
    // Add new volunteer to DB
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(Volunteer volunteer)
    {
        if (ModelState.IsValid)
        {
            _db.Volunteers.Add(volunteer);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(volunteer);
    }
    
    // Display page to delete a volunteer
    public async Task<IActionResult> Delete(int? id)
    {
        var volunteer = await _db.Volunteers.FindAsync(id);

        if (volunteer == null)
        {
            return NotFound();
        }
        
        return View(volunteer);
    }
    
    // Delete volunteer from DB
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var volunteer = await _db.Volunteers.FindAsync(id);

        if (volunteer != null)
        {
            _db.Volunteers.Remove(volunteer);
            await _db.SaveChangesAsync();
        }
        
        return RedirectToAction(nameof(Index));
    }
    
    // View and search for volunteers 
    // VVV          AI-assisted code          VVV
    public IActionResult Index(string search, string filter = "All")
    {
        var query = _db.Volunteers.AsQueryable();

        // Apply status filter
        query = filter switch
        {
            "Approved"         => query.Where(v => v.Status == VolunteerStatus.Approved),
            "Pending"          => query.Where(v => v.Status == VolunteerStatus.Pending),
            "Disapproved"      => query.Where(v => v.Status == VolunteerStatus.Disapproved),
            "Inactive"         => query.Where(v => v.Status == VolunteerStatus.Inactive),
            "ApprovedPending"  => query.Where(v => v.Status == VolunteerStatus.Approved || v.Status == VolunteerStatus.Pending),
            _                  => query // "All" — no filter
        };

        // Apply search term
        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalizedSearch = search.ToLower();
            query = query.Where(v =>
                v.FirstName.ToLower().Contains(normalizedSearch) ||
                v.LastName.ToLower().Contains(normalizedSearch));
        }

        List<Volunteer> objVolunteerList = query.ToList();

        ViewData["CurrentFilter"] = filter;
        ViewData["CurrentSearch"] = search;

        return View(objVolunteerList);
    } // ^^^          End of AI-assisted code          ^^^
      // "Project AI Use" Item 2 -  This code was written in collaboration with Anthropic. (2026). Claude [Large language model]. https://claude.ai/
      
      //Temp just so the page can show up
      public IActionResult Matches(int id)
      {
          return View(new List<Match>());
      }
}


