using ApiGateway.Src.DTOs.Models;

namespace ApiGateway.Src.DTOs.Resources
{
    public class ResourceDto : BaseModelDto
    {
        public string Type { get; set; } = null!;

        public int TypeCode { get; set; }

        public string Url { get; set; } = null!;

        public int SubjectResourceId { get; set; }
    }
}