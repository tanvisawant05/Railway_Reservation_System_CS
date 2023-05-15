using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Railway_Reservation_System_CS.Models
{
    public class Payment
    {
        [Key]
        public int Payment_id { get; set; } 

        

        [Required]
        [ForeignKey("ReservationId")]
        public int ReservationId { get; set; } 

        

        [Required]
        public DateTime PaymentDateTime { get; set; }

        

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; }

        

        [Required]
        [StringLength(50)]
        public string PaymentStatus { get; set; }

        

        [Required]
        [Range(1, int.MaxValue)]
        public float TotalAmount { get; set; }

        

        [JsonIgnore]
        public Reservation Reservation { get; set; }

    }
}
