using System.ComponentModel.DataAnnotations;

namespace EventManagementAPI.Models
{
    public class Register
    {
            [Key]
            public string Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }



    }
}
