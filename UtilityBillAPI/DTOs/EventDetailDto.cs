using System.ComponentModel.DataAnnotations;

namespace EventManagementAPI.DTOs
{
    public class EventDetailDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Event Name is required")]
        [StringLength(100, ErrorMessage = "Event Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Event Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "VenueId is required")]
        public int VenueId { get; set; }


        [Required(ErrorMessage = "CategoryId is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "ArtistId is required")]
        public int ArtistId { get; set; }

        [Required(ErrorMessage = "OrganizerId is required")]
        public int OrganizerId { get; set; }

        public string Tags { get; set; }


    }
}
