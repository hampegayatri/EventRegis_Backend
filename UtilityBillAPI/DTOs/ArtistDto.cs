using System.ComponentModel.DataAnnotations;

namespace EventManagementAPI.DTOs
{
    public class ArtistDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Bio can't be longer than 500 characters")]
        public string Bio { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [StringLength(50, ErrorMessage = "Genre can't be longer than 50 characters")]
        public string Genre { get; set; }

        [StringLength(100, ErrorMessage = "Contact info can't be longer than 100 characters")]
        public string ContactInfo { get; set; }

    }
}

