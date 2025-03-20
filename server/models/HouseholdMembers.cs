namespace server.Models
{
    public class HouseholdMembers
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}