using System.ComponentModel.DataAnnotations;

namespace server.Models;

    public class Household
    {
        public int Id { get; set; }
        [Required]
        public required string RecipientFirst { get; set; }
        [Required]
        public required string RecipientLast { get; set; }
        [Required]
        public required string Address { get; set; }
        public required int Members { get; set; } = 0;
        public required int Infants { get; set; } = 0;
        public required int Toddlers { get; set; } = 0;
        public required int Children { get; set; } = 0;
        public required int Adults { get; set; } = 0;
        public required int Seniors { get; set; } = 0;
        [Required]
        [RegularExpression(@"^(Categorical|Income)$", ErrorMessage = "EligibilityType must be either 'Categorical' or 'Income'.")]
        public required string EligibilityType { get; set; }
        public required DateTime EligibilityAttestationDate { get; set; } = DateTime.Now;
        public required DateTime LastUpdated { get; set; } = DateTime.Now;
        public string? Others_Authorized { get; set; }

        /// Navigation properties
        public List<HouseholdMember>? HouseholdMembers { get; set; } = null!;
        public List<HouseholdVisit>? HouseholdVisits { get; set; } = null!;
    }
