using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceMarketingSystem.Models
{
    public class UserRefreshToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Refresh token is required")]
        public string? RefreshToken { get; set; }

        [Required(ErrorMessage = "RefreshTokenExpiryTime is required")]
        public DateTime RefreshTokenExpiryTime { get; set; }

        public bool IsActived { get; set; } = true;
    }
}
