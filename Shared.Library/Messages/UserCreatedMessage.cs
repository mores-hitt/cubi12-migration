namespace Shared.Library.Messages
{
    public class UserCreatedMessage
    {
        public string? Name { get; set; } = null!;

        public string? FirstLastName { get; set; } = null!;

        public string? SecondLastName { get; set; } = null!;

        public string? RUT { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int CareerId { get; set; }

        public int RoleId { get; set; }

        public string Password { get; set; } = null!;

    }
}