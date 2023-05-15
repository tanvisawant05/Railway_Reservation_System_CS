using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Railway_Reservation_System_CS.Models
{
    public class Train
    {
        [Key]
        public int TrainId { get; set; } 

        

        [Required(ErrorMessage = "Train name is required")]
        [StringLength(50)]
        public string TrainName { get; set; }

        

        [Required(ErrorMessage = "Source is required")]
        [StringLength(50)]
        [DisplayName("Source")]
        public string Source { get; set; }

        

        [Required(ErrorMessage = "Destination is required")]
        [StringLength(50)]
        [DisplayName("Destination")]
        public string Destination { get; set; }

        

        [Required(ErrorMessage = "Departure time is required")]
        [DataType(DataType.DateTime)]
        public DateTime DepartureTime { get; set; }

        

        [Required(ErrorMessage = "Arrival time is required")]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalTime { get; set; }

       

        [Required(ErrorMessage = "Available seats is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Available seats should be greater than or equal to 0")]
        public int AvailableSeats { get; set; }

        

        [Required(ErrorMessage = "Price is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Price should be greater than 0")]
        public float Price { get; set; }


    }
}