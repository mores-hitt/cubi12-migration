using System.ComponentModel.DataAnnotations;
using Auth.Src.Common;

namespace Auth.Src.DTOs.Auth
{
    public class UpdatePasswordDto
    {
        [Required]
        public string CurrentPassword  { get; set; } = null!;

        [Required]
        [StringLength(16, MinimumLength = 10)]
        [RegularExpression(RegularExpressions.PasswordValidation,
            ErrorMessage = "Password must have at least one letter and one number")
        ]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password))]
        public string RepeatedPassword { get; set; } = null!;
    }
}