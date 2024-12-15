using ApiGateway.Src.DTOs.Models;

namespace ApiGateway.Src.DTOs.Subjects
{
    public class SubjectRelationshipDto : BaseModelDto
    {
        public string SubjectCode { get; set; } = null!;
        
        public string PreSubjectCode { get; set; } = null!;
    }
}