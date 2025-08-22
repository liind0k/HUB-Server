using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICTInfoHub.Model.Model
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [EnumDataType(typeof(Priority))]
        public String Priority { get; set; }
        [Required]
        [EnumDataType(typeof(NewsCategory))]
        public string Category { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public byte[]? DocFile { get; set; }
        [Required]
        public int? CampusId { get; set; }
        [ForeignKey(nameof(CampusId))]
        public Campus? Campus { get; set; }
        [Required]
        public int AdminId { get; set; }
        [ForeignKey(nameof(AdminId))]
        public Admin Admin { get; set; }

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
