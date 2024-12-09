using System.ComponentModel.DataAnnotations;

namespace user_microservice.Src.Models
{
    public class Role : BaseModel
    {
        [StringLength(250)]
        public string Name { get; set; } = null!;

        [StringLength(250)]
        public string Description { get; set; } = null!;
    }
}