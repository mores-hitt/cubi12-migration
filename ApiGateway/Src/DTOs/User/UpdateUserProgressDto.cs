namespace ApiGateway.Src.DTOs.User
{
    public class UpdateUserProgressDto
    {
        public List<string> add_subjects { get; set; } = new List<string>();

        public List<string> delete_subjects { get; set; } = new List<string>();
    }
}