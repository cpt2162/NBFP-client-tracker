namespace server.Models;

public class HouseholdVisit
{
    public int Id { get; set; }
    public required int HouseholdId { get; set; }
    public required DateTime VisitDate { get; set; }
    public required string StaffName { get; set; }

    /// Navigation prop
    public Household Household { get; set; } = null!;
}
