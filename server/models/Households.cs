namespace server.Models
{
    public class Households
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Members { get; set; }
        public int Infants { get; set; }
        public int Toddlers { get; set; }
        public int Children { get; set; }
        public int Adults { get; set; }
        public int Seniors { get; set; }
        public string EligibilityType { get; set; }
        public DateTime EligibilityAttestationDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Others_Authorized { get; set; }
    }
}