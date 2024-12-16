using ApiGateway.Src.DTOs.Models;

namespace ApiGateway.Src.DTOs.Subjects
{
    public class SubjectDto : BaseModelDto
    {
        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Department { get; set; } = null!;

        public int Credits { get; set; }

        public int Semester { get; set; }
    }
}