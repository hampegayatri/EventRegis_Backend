using EventManagementAPI.Models;
using System.ComponentModel.DataAnnotations;

public class Organizer
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Organizer Name is required")]
    [StringLength(100, ErrorMessage = "Organizer Name can't be longer than 100 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [StringLength(100, ErrorMessage = "Email can't be longer than 100 characters")]
    public string Email { get; set; }

    [Phone(ErrorMessage = "Invalid Contact Number")]
    [StringLength(15, ErrorMessage = "Contact Number can't be longer than 15 characters")]
    public string ContactNumber { get; set; }

}
