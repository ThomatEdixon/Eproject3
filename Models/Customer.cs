using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eProject3.Model
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        //[RegularExpression("^[a-zA-Z0-9]{11}$", ErrorMessage = "The code of customer must contains 11 characters !")]
        public string? Cus_code { get; set; }
        [Required(ErrorMessage = "Customer Name must be not null!")]
        public string? Cus_name { get; set; }
        [Required]
        public string? Cus_phone { get; set; }
        [Required]
        public string? Cus_address { get; set; }
        [EmailAddress(ErrorMessage = "Email is invalid!")]
        public string? Cus_email { get; set; }
        [Required]
        [MinLength(8)]
        public string? Password { get; set; }
    }
}
