namespace server.Models
{
    public class HouseholdVisits
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public DateTime VisitDate { get; set; }
        public string StaffName { get; set; }
    }
}