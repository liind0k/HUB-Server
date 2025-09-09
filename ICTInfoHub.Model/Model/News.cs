using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ICTInfoHub.Model.Model
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }
        [Required]
        public string NewsTitle { get; set; }
        [Required]
        public string NewsDescription { get; set; }
        [Required]
        [EnumDataType(typeof(Priority))]
        public string Priority { get; set; }
        [Required]
        [EnumDataType(typeof(NewsCategory))]
        public string Category { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public byte[]? DocFile { get; set; }
        [Required]
        [JsonIgnore]
        public ICollection<Campus?> Campuses { get; set; } = new List<Campus?>();
        [Required]
        public int AdminId { get; set; }
        [ForeignKey(nameof(AdminId))]
        public Admin Admin { get; set; }
        [Required]
        public bool IsVisible { get; set; }

    }

    public enum Priority
    {
        high,
        medium,
        low
    }
    public enum NewsCategory
    {
        Announcement,
        Academic,
        Registration,
        Event,
        WIL

    }
}
