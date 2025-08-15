using System.ComponentModel.DataAnnotations;

namespace ICTInfoHub.Model.Model
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [EnumDataType(typeof(Priority))]
        public String Priority { get; set; }

        [Required]
        public bool IsDepartment { get; set; }

        [Required]
        public string Category { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public string? DocLocation { get; set; }

        [Required]
        [EnumDataType(typeof(Campus))]
        public string? Campus { get; set; }


    }
    public enum Campus{
        emalahleni,
        polokwane,
        soshanguve
    }
    public enum Priority{
        urgent,
        moderate,
        low
    }
}
