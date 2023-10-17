using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eProject3.Model
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(Order.Id))]
        public int Order_id { get; set; }
        [Required]
        public string? Account_code { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public string? Active { get; set; }

        public virtual Order? order { get; }

    }
}
