using Microsoft.EntityFrameworkCore;

namespace server.Models;

public class NBFPDbContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Household> Household { get; set; }
    public DbSet<HouseholdMember> HouseholdMember { get; set; }
    public DbSet<HouseholdVisit> HouseholdVisit { get; set; }

    public NBFPDbContext(DbContextOptions<NBFPDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HouseholdMember>()
            .HasOne(hm => hm.Household)
            .WithMany(h => h.HouseholdMembers)
            .HasForeignKey(hm => hm.HouseholdId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<HouseholdVisit>()
            .HasOne(hv => hv.Household)
            .WithMany(h => h.HouseholdVisits)
            .HasForeignKey(hv => hv.HouseholdId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "nbfpAdmin", Password = "nbfpfeedsmore" }
        );

        modelBuilder.Entity<Household>().HasData(
            new Household { Id = 1, RecipientFirst = "Dayquan", RecipientLast = "Jones", Address = "123 Main St, Buffalo, NY, 14203", Members = 5, Infants = 1, Toddlers = 1, Children = 2, Adults = 1, Seniors = 0, EligibilityType = "Categorical", EligibilityAttestationDate = DateTime.UtcNow.AddDays(-10), LastUpdated = DateTime.UtcNow.AddDays(-10) },
            new Household { Id = 2, RecipientFirst = "Daniel", RecipientLast = "Abrams", Address = "456 Elm St, Buffalo, NY, 14203", Members = 3, Infants = 0, Toddlers = 0, Children = 1, Adults = 2, Seniors = 0, EligibilityType = "Income", EligibilityAttestationDate = DateTime.UtcNow.AddDays(-5), LastUpdated = DateTime.UtcNow.AddDays(-5) }
        );

        modelBuilder.Entity<HouseholdMember>().HasData(
            new HouseholdMember { Id = 1, FirstName = "John", LastName = "Doe", HouseholdId = 1 },
            new HouseholdMember { Id = 2, FirstName = "Jane", LastName = "Doe", HouseholdId = 1 },
            new HouseholdMember { Id = 3, FirstName = "Alice", LastName = "Doe", HouseholdId = 1 },
            new HouseholdMember { Id = 4, FirstName = "Bob", LastName = "Doe", HouseholdId = 1 },
            new HouseholdMember { Id = 5, FirstName = "Al", LastName = "Doe", HouseholdId = 1 },
            new HouseholdMember { Id = 6, FirstName = "Alice", LastName = "Smith", HouseholdId = 2 },
            new HouseholdMember { Id = 7, FirstName = "Bob", LastName = "Smith", HouseholdId = 2 },
            new HouseholdMember { Id = 8, FirstName = "Charlie", LastName = "Smith", HouseholdId = 2 }
        );

        modelBuilder.Entity<HouseholdVisit>().HasData(
            new HouseholdVisit { Id = 1, HouseholdId = 1, StaffName = "Cameron Turner", VisitDate = DateTime.UtcNow.AddDays(-5) },
            new HouseholdVisit { Id = 2, HouseholdId = 2, StaffName = "Cameron Turner", VisitDate = DateTime.UtcNow.AddDays(-2) }
        );
    }
}