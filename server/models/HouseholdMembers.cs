namespace server.Models
{
    public class HouseholdMembers
    {
        public int Id { get; set; }
        public required int HouseholdId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int Age { get; set; }
    }
}