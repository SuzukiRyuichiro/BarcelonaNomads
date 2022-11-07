using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BarcelonaNomads.Models;

namespace BarcelonaNomads.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<BarcelonaNomads.Models.Location>? Locations { get; set; }
    public DbSet<BarcelonaNomads.Models.Review>? Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Review>()
            .HasOne(review => review.Location)
            .WithMany(location => location.Reviews)
            .HasForeignKey(review => review.LocationId);
    }

}

 