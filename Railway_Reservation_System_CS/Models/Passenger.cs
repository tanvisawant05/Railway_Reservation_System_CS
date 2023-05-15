using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Railway_Reservation_System_CS.Models
{
    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; } 

        

        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; }


        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(40)]
        public string Name { get; set; }


        [DisplayName("EmailId")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailId { get; set; }

        

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$",
        ErrorMessage = "Password should be between 8 to 10 characters, and contain at least one lowercase letter, one uppercase letter, one numeric digit, and one special character.")]
        public string Password { get; set; }


        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone_no { get; set; }



        [DisplayName("Age")]
        [Required(ErrorMessage = "Age is required")]
        [Range(1, 100, ErrorMessage = "Age must be valid")]
        public int Age { get; set; }



        [DisplayName("Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        

        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public IEnumerable<Reservation> reservation { get; set; }

       
    }
}
