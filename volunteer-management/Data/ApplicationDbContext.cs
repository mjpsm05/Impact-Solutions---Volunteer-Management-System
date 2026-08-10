using Microsoft.EntityFrameworkCore;
using volunteer_management.Models;

namespace volunteer_management.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Volunteer> Volunteers => Set<Volunteer>();
    public DbSet<Opportunity> Opportunities => Set<Opportunity>();
    public DbSet<Match> Matches => Set<Match>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Volunteer>(entity =>
        {
            // Identification
            entity.Property(v => v.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(v => v.LastName).IsRequired().HasMaxLength(100);

            // Account information
            entity.Property(v => v.Username).IsRequired().HasMaxLength(100);

            // Contact information
            entity.Property(v => v.Email).IsRequired().HasMaxLength(254);
            entity.Property(v => v.HomePhone).HasMaxLength(30);
            entity.Property(v => v.WorkPhone).HasMaxLength(30);
            entity.Property(v => v.CellPhone).HasMaxLength(30);

            // Address information
            entity.Property(v => v.AddressLine1).HasMaxLength(200);
            entity.Property(v => v.AddressLine2).HasMaxLength(200);
            entity.Property(v => v.City).HasMaxLength(100);
            entity.Property(v => v.State).HasMaxLength(100);
            entity.Property(v => v.PostalCode).HasMaxLength(20);

            // Volunteer preferences
            entity.Property(v => v.PreferredCenters).HasMaxLength(500);
            entity.Property(v => v.SkillsInterests).HasMaxLength(1000);
            entity.Property(v => v.Availability).HasMaxLength(1000);

            // Background information
            entity.Property(v => v.EducationalBackground).HasMaxLength(2000);
            entity.Property(v => v.CurrentLicenses).HasMaxLength(1000);

            // Emergency contact
            entity.Property(v => v.EmergencyContactName).HasMaxLength(200);
            entity.Property(v => v.EmergencyContactHomePhone).HasMaxLength(30);
            entity.Property(v => v.EmergencyContactWorkPhone).HasMaxLength(30);
            entity.Property(v => v.EmergencyContactEmail).HasMaxLength(254);
            entity.Property(v => v.EmergencyContactAddress).HasMaxLength(500);

            // Documents on file
            entity.Property(v => v.HasDriversLicenseCopy).HasDefaultValue(false);
            entity.Property(v => v.HasSocialSecurityCardCopy).HasDefaultValue(false);

            // Approval status
            entity.Property(v => v.Status).HasConversion<string>().HasMaxLength(20).HasDefaultValue(VolunteerStatus.Pending);

            entity.HasIndex(v => v.Email).IsUnique();
            entity.HasIndex(v => v.Username).IsUnique();
            entity.HasIndex(v => v.LastName);
            entity.HasIndex(v => v.Status);
        });

        modelBuilder.Entity<Opportunity>(entity =>
        {
            entity.Property(o => o.Name).IsRequired().HasMaxLength(200);
            entity.Property(o => o.Description).HasMaxLength(2000);
            entity.Property(o => o.Center).HasMaxLength(200);

            entity.HasIndex(o => o.Name);
            entity.HasIndex(o => o.Center);
            entity.HasIndex(o => o.CreatedAt);
        });
        
        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasOne(m => m.Volunteer)
                .WithMany(v => v.Matches)
                .HasForeignKey(m => m.VolunteerId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(m => m.Opportunity)
                .WithMany(o => o.Matches)
                .HasForeignKey(m => m.OpportunityId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(m => new
            {
                m.VolunteerId,
                m.OpportunityId
            }).IsUnique();
        });
    }
}
