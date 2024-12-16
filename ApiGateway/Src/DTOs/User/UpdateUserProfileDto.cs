namespace ApiGateway.Src.DTOs.User
{
    public class UpdateUserProfileDto
    {
        public string name { get; set; } = null!;

        public string first_last_name { get; set; } = null!;

        public string second_last_name { get; set; } = null!;

    }
}