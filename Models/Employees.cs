using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace ServiceMarketingSystem.Models
{
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(Roles.Id))]
        public int RoleId { get; set; }
        [ForeignKey(nameof(Stores.Id))]
        public int StoreId { get; set; }
        [Required(ErrorMessage = "Employee Name must be not null!")]
        public string? EmpName { get; set; }
        public DateTime Dob { get; set; }
        public string? EmpPhone { get; set; }
        public string? EmpAddress { get; set;}
        [Required]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string? EmpEmail { get; set;}
        public string? Password { get; set; }
        public virtual Roles? Role { get; set; }
        public virtual Stores? Store { get; set; }
    }
}
