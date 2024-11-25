using System.ComponentModel.DataAnnotations;

namespace user_microservice.Src.Models
{
    public class SubjectRelationship : BaseModel
    {
        [StringLength(250)]
        public string SubjectCode { get; set; } = null!;

        [StringLength(250)]
        public string PreSubjectCode { get; set; } = null!;
    }
}