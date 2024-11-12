using System.ComponentModel.DataAnnotations;

public class EventRegistrationDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "UserId is required")]
    public string UserId { get; set; }

    [Required(ErrorMessage = "EventId is required")]
    public int EventId { get; set; }

    [Required(ErrorMessage = "TicketTypeId is required")]
    public int TicketTypeId { get; set; }

    [Required(ErrorMessage = "Registration Date is required")]
    public DateTime RegistrationDate { get; set; }

    [Required(ErrorMessage = "First Name is required")]
    [StringLength(50, ErrorMessage = "First Name can't be longer than 50 characters")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required")]
    [StringLength(50, ErrorMessage = "Last Name can't be longer than 50 characters")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [StringLength(100, ErrorMessage = "Email can't be longer than 100 characters")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Mobile Number is required")]
    [Phone(ErrorMessage = "Invalid Mobile Number")]
    [StringLength(15, ErrorMessage = "Mobile Number can't be longer than 15 characters")]
    public string MobileNumber { get; set; }

    [Required(ErrorMessage = "Age is required")]
    [Range(5, 80, ErrorMessage = "Age must be between 5 and 80")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    [StringLength(10, ErrorMessage = "Gender can't be longer than 10 characters")]
    public string Gender { get; set; }
    public string Status { get; set; } = "Approved";
}
