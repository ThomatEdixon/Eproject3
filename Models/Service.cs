using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eProject3.Model
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Ser_name { get; set; }
        [Required]
        public double Ser_price { get; set; }
        [Required]
        public string? Ser_device { get; set; }
    }
}
