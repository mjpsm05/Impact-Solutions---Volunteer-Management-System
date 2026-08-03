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
    // Identification
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    // Account information
    // Authentication is not yet implemented. When it is, credentials must be
    // handled via ASP.NET Core Identity or a secure password-hashing approach
    // (e.g. PBKDF2/BCrypt). Do not add a plaintext password property here.
    public string Username { get; set; } = string.Empty;

    // Contact information
    public string Email { get; set; } = string.Empty;
    public string? HomePhone { get; set; }
    public string? WorkPhone { get; set; }
    public string? CellPhone { get; set; }

    // Address information
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }

    // Volunteer preferences
    public string? PreferredCenters { get; set; }
    public string? SkillsInterests { get; set; }
    public string? Availability { get; set; }

    // Background information
    public string? EducationalBackground { get; set; }
    public string? CurrentLicenses { get; set; }

    // Emergency contact
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactHomePhone { get; set; }
    public string? EmergencyContactWorkPhone { get; set; }
    public string? EmergencyContactEmail { get; set; }
    public string? EmergencyContactAddress { get; set; }

    // Documents on file (status only — no document content or ID numbers stored)
    public bool HasDriversLicenseCopy { get; set; }
    public bool HasSocialSecurityCardCopy { get; set; }

    // Approval status
    public VolunteerStatus Status { get; set; } = VolunteerStatus.Pending;

    // Audit fields
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}