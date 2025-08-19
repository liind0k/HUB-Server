using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Department { get; set; }
        [Required]
        [EnumDataType(typeof(Priority))]
        public String Priority { get; set; }
        [Required]
        [EnumDataType (typeof(NewsCategory))]
        public string Category { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        [NotMapped]
        public IFormFile? DocFile { get; set; }
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
    public enum NewsCategory
    {
        department,
        faculty
    }
    public enum Department
    {
        computerScience,
        informationTechnology,
        infomatics,
        computerSystemsEngineering

    }
}
