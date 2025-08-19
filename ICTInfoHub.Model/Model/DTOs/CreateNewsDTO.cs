using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ICTInfoHub.Model.Model.DTOs
{
    public class CreateNewsDTO
    {
        [Required(ErrorMessage = "Admin ID is required")]
        [ForeignKey("AdminId")]
        public int AdminId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [EnumDataType(typeof(Priority))]
        public string Priority { get; set; }

        [Required]
        [EnumDataType (typeof(NewsCategory))]
        public string Category { get; set; }
        [EnumDataType(typeof(Department))]
        public string Department { get; set; }
        [Required]
        [EnumDataType (typeof(Campus))]
        public string Campus { get; set; }
        [NotMapped]
        public IFormFile? DocFile { get; set; }

    }
}
