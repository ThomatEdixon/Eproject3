using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eProject3.Model
{
    public class Vendor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Vendor_name { get; set; }
        [Required]
        public string? Vendor_phone { get; set; }
        [Required]
        public string? Vendor_address { get; set; }
        [EmailAddress(ErrorMessage = "Email is invalid!")]
        public string? Vendor_email { get; set;}

    }
}
