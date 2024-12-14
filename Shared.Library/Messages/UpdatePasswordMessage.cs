namespace Shared.Library.Messages
{
    public class UpdatePasswordMessage
    {
        public int Id { get; set; }

        public string Password { get; set; } = null!;

    }
}