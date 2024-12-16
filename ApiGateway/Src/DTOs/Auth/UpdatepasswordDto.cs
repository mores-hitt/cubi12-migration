using System.ComponentModel.DataAnnotations;

namespace ApiGateway.Src.DTOs.Auth
{
    public class UpdatePasswordDto
    {
        [Required]
        public string CurrentPassword  { get; set; } = null!;

        [Required]
        [StringLength(16, MinimumLength = 10)]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password))]
        public string RepeatedPassword { get; set; } = null!;
    }
}