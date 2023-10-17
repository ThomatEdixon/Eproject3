using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eProject3.Model
{
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Contract_code { get; set; }
        [ForeignKey(nameof(Service.Id))]
        public int Ser_id { get; set; }
        [ForeignKey(nameof(Customer.Id))]
        public int Cus_id { get; set;}
        [Required]
        [DataType(DataType.Date)]
        public DateTime Contract_date { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Expire_date { get; set; }
        [Required]
        public double Total_amount { get; set; }
        [Required]
        public double Deposit { get; set;}

        public virtual Service? service { get; }
        public virtual Customer? customer { get; }


    }
}
