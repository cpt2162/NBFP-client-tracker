using Microsoft.EntityFrameworkCore;

namespace server.Models;

public class NBFPDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public NBFPDbContext(DbContextOptions<NBFPDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Households> Households { get; set; }
    public DbSet<HouseholdMembers> HouseholdMembers { get; set; }
    public DbSet<HouseholdVisits> HouseholdVisits { get; set; }
}