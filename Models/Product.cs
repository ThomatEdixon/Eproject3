﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eProject3.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }     
        [NotMapped]
        public IFormFile? Avatar { get; set; }
        public string? ImagePath { get; set; }
        [Required]
        public string? Prd_name { get; set; }
        [Required]
        public double Prd_price { get; set; }
        [ForeignKey(nameof(Vendor.Id))]
        public int Vendor_id { get; set;}
        public virtual Vendor? vendor { get; }
    }
}
