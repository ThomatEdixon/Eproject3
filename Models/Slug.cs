using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceMarketingSystem.Models
{
    public class Slug
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(Roles.Id))]
        public int RoleId { get; set; }
        public string? URI { get; set; }
        public string? URIName { get; set; }
        public virtual Roles? Role { get; set; }
    }
}
