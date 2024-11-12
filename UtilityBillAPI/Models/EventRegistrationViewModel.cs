public class EventRegistrationViewModel
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public int TicketTypeId { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public bool IsWaitlisted { get; set; }
}
