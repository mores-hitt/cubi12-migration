using System.ComponentModel.DataAnnotations;

namespace Career.Src.Models
{
    public class Career : BaseModel
    {
        [StringLength(250)]
        public string Name { get; set; } = null!;
    }
}