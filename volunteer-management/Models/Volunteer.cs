namespace volunteer_management.Models;

public enum VolunteerStatus
{
    Pending,
    Approved,
    Disapproved,
    Inactive
}

public class Volunteer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? Skills { get; set; }
    public string? Availability { get; set; }
    public VolunteerStatus Status { get; set; } = VolunteerStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
