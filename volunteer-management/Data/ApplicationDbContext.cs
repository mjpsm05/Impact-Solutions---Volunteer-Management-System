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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Volunteer>(entity =>
        {
            entity.Property(v => v.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(v => v.LastName).IsRequired().HasMaxLength(100);
            entity.Property(v => v.Email).IsRequired().HasMaxLength(256);
            entity.Property(v => v.Phone).HasMaxLength(20);
            entity.Property(v => v.Address).HasMaxLength(300);
            entity.Property(v => v.Skills).HasMaxLength(500);
            entity.Property(v => v.Availability).HasMaxLength(500);
            entity.Property(v => v.Status).HasConversion<string>().HasMaxLength(20);

            entity.HasIndex(v => v.Email).IsUnique();
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
    }
}
