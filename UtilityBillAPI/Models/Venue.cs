using System.ComponentModel.DataAnnotations;

namespace EventManagementAPI.Models
{
    public class Venue
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Venue Name is required")]
        [StringLength(100, ErrorMessage = "Venue Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200, ErrorMessage = "Address can't be longer than 200 characters")]
        public string Address { get; set; }

        public string City { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than 0")]
        public int Capacity { get; set; }

    }
}
