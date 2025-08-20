using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;


namespace ICTInfoHub.Model.Model.DTOs
{
    public class UpdateNewsDTO
    {
        [Required]
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [EnumDataType(typeof(Priority))]
        public string Priority { get; set; }       
        public string Category { get; set; }
        public IFormFile formFile { get; set; }
        [EnumDataType (typeof(Campus))]
        public string Campus { get; set; }
        [EnumDataType(typeof (Department))]
        public string Department { get; set; }
    }
}
