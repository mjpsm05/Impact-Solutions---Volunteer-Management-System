namespace volunteer_management.Models;

public class Match
{
    public int Id { get; set; }

    public int VolunteerId { get; set; }
    public Volunteer Volunteer { get; set; } = null!;

    public int OpportunityId { get; set; }
    public Opportunity Opportunity { get; set; } = null!;
 
    
    
}