using System.ComponentModel.DataAnnotations;

namespace ICTInfoHub.Model.Model.DTOs
{
    public class CreateNewsDTO
    {
        [Required(ErrorMessage = "Admin ID is required")]
        public int AdminId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [EnumDataType(typeof(Priority))]
        public string Priority { get; set; }

        [Required]
        public bool IsDepartment { get; set; }

        [Required]
        public string Category { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public IFormFile? DocFile { get; set; }

    }
}
