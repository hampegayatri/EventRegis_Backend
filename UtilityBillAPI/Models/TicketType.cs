using System.ComponentModel.DataAnnotations;

namespace EventManagementAPI.Models
{
    public class TicketType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "EventId is required")]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Max Capacity must be greater than 0")]
        public int MaxCapacity { get; set; }


        public int AvailableQuantity { get; set; }
    }
}
