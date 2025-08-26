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
        [Required]
        public List<int> CampusIds { get; set; }
        public IFormFile? FormFile { get; set; }
        public byte[]? Document;
    }
}
