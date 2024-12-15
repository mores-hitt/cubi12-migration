using System.ComponentModel.DataAnnotations;

namespace Career.Src.Models
{
    public class Career : BaseModel
    {
        public int IdCode { get; set; }
        [StringLength(250)]
        public string Name { get; set; } = null!;
    }
}