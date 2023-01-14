using System.ComponentModel.DataAnnotations;

namespace PaymentBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public int Budget { get; set; }
        public bool IsVerified { get; set; }
    }
}
