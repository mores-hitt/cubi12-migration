using System.ComponentModel.DataAnnotations;

namespace ApiGateway.Src.DTOs.Auth
{
    public class LoginRequestDto
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}