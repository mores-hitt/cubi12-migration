using System.ComponentModel.DataAnnotations;

namespace Auth.Src.Models
{
    public class Role : BaseModel
    {
        [StringLength(250)]
        public string Name { get; set; } = null!;

        [StringLength(250)]
        public string Description { get; set; } = null!;
    }
}