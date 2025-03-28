namespace server.Models;
    public class Household
    {
        public int Id { get; set; }
        public required string Address { get; set; }
        public required int Members { get; set; } = 0;
        public required int Infants { get; set; } = 0;
        public required int Toddlers { get; set; } = 0;
        public required int Children { get; set; } = 0;
        public required int Adults { get; set; } = 0;
        public required int Seniors { get; set; } = 0;
        public required string EligibilityType { get; set; }
        public required DateTime EligibilityAttestationDate { get; set; } = DateTime.Now;
        public required DateTime LastUpdated { get; set; } = DateTime.Now;
        public string? Others_Authorized { get; set; }
    }
