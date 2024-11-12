using System.ComponentModel.DataAnnotations;

namespace EventManagementAPI.Models.Account
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
