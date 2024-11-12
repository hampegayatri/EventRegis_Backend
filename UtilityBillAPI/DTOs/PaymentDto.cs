using System.ComponentModel.DataAnnotations;

namespace EventManagementAPI.DTOs
{
    public class PaymentDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Total Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total Amount must be greater than 0")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Payment Date is required")]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Payment Status is required")]
        [StringLength(50, ErrorMessage = "Payment Status can't be longer than 50 characters")]
        public string PaymentStatus { get; set; }

        public int EventRegistrationId { get; set; }
    }
}
