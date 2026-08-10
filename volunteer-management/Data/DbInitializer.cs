using Microsoft.EntityFrameworkCore;
using volunteer_management.Models;

namespace volunteer_management.Data;

public class DbInitializer
{
    public static async Task InitializeAsync(ApplicationDbContext context)
    {
        // Apply any migrations that have not yet been applied.
        await context.Database.MigrateAsync();

        await SeedVolunteersAsync(context);
        await SeedOpportunitiesAsync(context);
        await SeedMatchesAsync(context);
    }

    private static async Task SeedVolunteersAsync(
        ApplicationDbContext context)
    {
        // Do not add duplicates if volunteer records already exist.
        if (await context.Volunteers.AnyAsync())
        {
            return;
        }

        var volunteers = new List<Volunteer>
        {
            new()
            {
                FirstName = "Jordan",
                LastName = "Williams",
                Username = "jordan.williams",
                Email = "jordan.williams@example.com",
                CellPhone = "904-555-0101",
                AddressLine1 = "125 River Street",
                City = "Jacksonville",
                State = "Florida",
                PostalCode = "32202",
                PreferredCenters = "Downtown Community Center",
                SkillsInterests =
                    "Event planning, community outreach, and mentoring",
                Availability =
                    "Monday and Wednesday evenings; Saturday mornings",
                EducationalBackground =
                    "Bachelor's degree in Business Administration",
                CurrentLicenses = "Valid Florida driver's license",
                EmergencyContactName = "Taylor Williams",
                EmergencyContactHomePhone = "904-555-0191",
                EmergencyContactEmail = "taylor.williams@example.com",
                EmergencyContactAddress =
                    "125 River Street, Jacksonville, Florida 32202",
                HasDriversLicenseCopy = true,
                HasSocialSecurityCardCopy = true,
                Status = VolunteerStatus.Approved,
                CreatedAt = DateTime.UtcNow
            },

            new()
            {
                FirstName = "Maya",
                LastName = "Johnson",
                Username = "maya.johnson",
                Email = "maya.johnson@example.com",
                HomePhone = "904-555-0102",
                CellPhone = "904-555-0112",
                AddressLine1 = "482 Pine Avenue",
                AddressLine2 = "Apartment 4B",
                City = "Jacksonville",
                State = "Florida",
                PostalCode = "32206",
                PreferredCenters =
                    "Northside Community Center, Youth Learning Center",
                SkillsInterests =
                    "Tutoring, reading assistance, and youth development",
                Availability =
                    "Tuesday and Thursday afternoons",
                EducationalBackground =
                    "Current university student studying education",
                EmergencyContactName = "Angela Johnson",
                EmergencyContactHomePhone = "904-555-0192",
                EmergencyContactEmail = "angela.johnson@example.com",
                EmergencyContactAddress =
                    "482 Pine Avenue, Jacksonville, Florida 32206",
                HasDriversLicenseCopy = false,
                HasSocialSecurityCardCopy = true,
                Status = VolunteerStatus.Pending,
                CreatedAt = DateTime.UtcNow
            },

            new()
            {
                FirstName = "Carlos",
                LastName = "Rivera",
                Username = "carlos.rivera",
                Email = "carlos.rivera@example.com",
                WorkPhone = "904-555-0103",
                CellPhone = "904-555-0113",
                AddressLine1 = "910 Atlantic Boulevard",
                City = "Jacksonville",
                State = "Florida",
                PostalCode = "32207",
                PreferredCenters =
                    "Southside Community Center",
                SkillsInterests =
                    "Food distribution, transportation, and logistics",
                Availability =
                    "Friday evenings and weekends",
                EducationalBackground =
                    "Associate degree in Logistics and Supply Chain Management",
                CurrentLicenses =
                    "Valid Florida driver's license; forklift certification",
                EmergencyContactName = "Elena Rivera",
                EmergencyContactWorkPhone = "904-555-0193",
                EmergencyContactEmail = "elena.rivera@example.com",
                EmergencyContactAddress =
                    "910 Atlantic Boulevard, Jacksonville, Florida 32207",
                HasDriversLicenseCopy = true,
                HasSocialSecurityCardCopy = false,
                Status = VolunteerStatus.Approved,
                CreatedAt = DateTime.UtcNow
            },

            new()
            {
                FirstName = "Avery",
                LastName = "Thompson",
                Username = "avery.thompson",
                Email = "avery.thompson@example.com",
                CellPhone = "904-555-0104",
                AddressLine1 = "275 Oak Lane",
                City = "Jacksonville",
                State = "Florida",
                PostalCode = "32210",
                PreferredCenters = "Westside Community Center",
                SkillsInterests =
                    "Graphic design, social media, and photography",
                Availability =
                    "Weekday evenings",
                EducationalBackground =
                    "Certificate in Digital Media",
                EmergencyContactName = "Morgan Thompson",
                EmergencyContactHomePhone = "904-555-0194",
                EmergencyContactEmail = "morgan.thompson@example.com",
                EmergencyContactAddress =
                    "275 Oak Lane, Jacksonville, Florida 32210",
                HasDriversLicenseCopy = false,
                HasSocialSecurityCardCopy = false,
                Status = VolunteerStatus.Disapproved,
                CreatedAt = DateTime.UtcNow
            },

            new()
            {
                FirstName = "Samuel",
                LastName = "Davis",
                Username = "samuel.davis",
                Email = "samuel.davis@example.com",
                HomePhone = "904-555-0105",
                AddressLine1 = "640 Beach Road",
                City = "Jacksonville Beach",
                State = "Florida",
                PostalCode = "32250",
                PreferredCenters =
                    "Beaches Community Center",
                SkillsInterests =
                    "Senior assistance, administrative support, and fundraising",
                Availability =
                    "Monday through Friday mornings",
                EducationalBackground =
                    "Retired accountant with 25 years of professional experience",
                CurrentLicenses = "Certified Public Accountant - inactive",
                EmergencyContactName = "Linda Davis",
                EmergencyContactHomePhone = "904-555-0195",
                EmergencyContactEmail = "linda.davis@example.com",
                EmergencyContactAddress =
                    "640 Beach Road, Jacksonville Beach, Florida 32250",
                HasDriversLicenseCopy = true,
                HasSocialSecurityCardCopy = true,
                Status = VolunteerStatus.Inactive,
                CreatedAt = DateTime.UtcNow
            }
        };

        await context.Volunteers.AddRangeAsync(volunteers);
        await context.SaveChangesAsync();
    }

    private static async Task SeedOpportunitiesAsync(
        ApplicationDbContext context)
    {
        // Do not add duplicates if opportunity records already exist.
        if (await context.Opportunities.AnyAsync())
        {
            return;
        }

        var opportunities = new List<Opportunity>
        {
            new()
            {
                Name = "Community Food Distribution",
                Description =
                    "Assist with organizing, packing, and distributing food packages to local families.",
                Center = "Downtown Community Center",
                StartDate = DateTime.UtcNow.Date.AddDays(7).AddHours(9),
                EndDate = DateTime.UtcNow.Date.AddDays(7).AddHours(13),
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            },

            new()
            {
                Name = "Youth Homework Assistance",
                Description =
                    "Help middle-school students complete homework and develop effective study habits.",
                Center = "Youth Learning Center",
                StartDate = DateTime.UtcNow.Date.AddDays(10).AddHours(15),
                EndDate = DateTime.UtcNow.Date.AddDays(10).AddHours(18),
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            },

            new()
            {
                Name = "Neighborhood Cleanup",
                Description =
                    "Work with community members to collect litter and improve shared outdoor areas.",
                Center = "Northside Community Center",
                StartDate = DateTime.UtcNow.Date.AddDays(14).AddHours(8),
                EndDate = DateTime.UtcNow.Date.AddDays(14).AddHours(12),
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            },

            new()
            {
                Name = "Senior Technology Workshop",
                Description =
                    "Assist older adults with smartphones, email, video calling, and basic online safety.",
                Center = "Westside Community Center",
                StartDate = DateTime.UtcNow.Date.AddDays(18).AddHours(10),
                EndDate = DateTime.UtcNow.Date.AddDays(18).AddHours(13),
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            },

            new()
            {
                Name = "Annual Fundraising Event",
                Description =
                    "Support event registration, guest assistance, setup, and cleanup for the annual fundraiser.",
                Center = "Southside Community Center",
                StartDate = DateTime.UtcNow.Date.AddDays(-30).AddHours(17),
                EndDate = DateTime.UtcNow.Date.AddDays(-30).AddHours(21),
                CreatedAt = DateTime.UtcNow.AddDays(-60),
                IsActive = false
            }
        };

        await context.Opportunities.AddRangeAsync(opportunities);
        await context.SaveChangesAsync();
    } 
    
    private static async Task SeedMatchesAsync(
        ApplicationDbContext context)
    {
        // Don't create duplicate test matches.
        if (await context.Matches.AnyAsync())
        {
            return;
        }

        var volunteers = await context.Volunteers.ToListAsync();
        var opportunities = await context.Opportunities.ToListAsync();

        var matches = new List<Match>();

        foreach (var volunteer in volunteers)
        {
            if (string.IsNullOrWhiteSpace(volunteer.PreferredCenters))
            {
                continue;
            }

            var preferredCenters = volunteer.PreferredCenters
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(center => center.Trim())
                .ToList();

            foreach (var opportunity in opportunities)
            {
                if (string.IsNullOrWhiteSpace(opportunity.Center))
                {
                    continue;
                }

                var centerMatches = preferredCenters.Any(center =>
                    string.Equals(
                        center,
                        opportunity.Center,
                        StringComparison.OrdinalIgnoreCase));

                if (centerMatches)
                {
                    matches.Add(new Match
                    {
                        VolunteerId = volunteer.Id,
                        OpportunityId = opportunity.Id
                    });
                }
            }
        }

        if (matches.Count > 0)
        {
            await context.Matches.AddRangeAsync(matches);
            await context.SaveChangesAsync();
        }
    }
}