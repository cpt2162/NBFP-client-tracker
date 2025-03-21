namespace server.Models
{
    public class HouseholdVisits
    {
        public int Id { get; set; }
        public required int HouseholdId { get; set; }
        public required DateTime VisitDate { get; set; }
        public required string StaffName { get; set; }
    }
}