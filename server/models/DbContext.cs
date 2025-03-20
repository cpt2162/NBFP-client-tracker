using Microsoft.EntityFrameworkCore;

namespace server.Models;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext(DbContextOptions<DbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Households> Households { get; set; }
    public DbSet<HouseholdMembers> HouseholdMembers { get; set; }
    public DbSet<HouseholdVisits> HouseholdVisits { get; set; }
}