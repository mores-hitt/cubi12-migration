namespace Auth.Src.DTO.Models
{
    public class RoleDto : BaseModelDto
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}