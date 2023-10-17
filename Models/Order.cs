using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eProject3.Model
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Status { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Order_date { get; set; }
        [ForeignKey(nameof(Product.Id))]
        public int Product_id { get; set; }
        [ForeignKey(nameof(Customer.Id))]
        public int Customer_id { get; set;}
        [Required]
        public int Quantity { get; set; }
        public virtual Product? product { get; }
        public virtual Customer? customer { get; }
    }
}
