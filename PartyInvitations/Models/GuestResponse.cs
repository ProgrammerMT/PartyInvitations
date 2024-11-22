using System.ComponentModel.DataAnnotations;

namespace PartyInvitations.Models
{
    public class GuestResponse
    {
        [Key] // Primary key attribute
        public int Id { get; set; }  // Primary key

        [Required] // Ensures the field is not null
        public string Name { get; set; }

        [Required]
        [Phone] // Validates phone format
        public string Phone { get; set; }

        [Required]
        [EmailAddress] // Validates email format
        public string Email { get; set; }

        public bool? WillAttend { get; set; }
    }
}
