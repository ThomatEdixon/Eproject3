using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using eProject3.Model;

namespace ServiceMarketingSystem.Models
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(Product.Id))]
        public int Product_id { get; set; }
        public double Rating { get; set; }
        public string? Content { get; set; }
        public virtual Product? product { get; set; }
    }
}
