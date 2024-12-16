namespace Career.Src.Models
{
    public abstract class BaseModel
    {
        public string Id { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public DateTime? DeletedAt { get; set; } = null;

        public int Version { get; set; } = 1;
    }
}