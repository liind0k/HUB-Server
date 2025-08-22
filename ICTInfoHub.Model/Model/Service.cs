using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ICTInfoHub.Model.Model
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        [Required]
        public string ServiceTitle { get; set; }
        [Required]
        public string ServiceDescription { get; set; }
        public string ServiceUrl { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public int CampusId { get; set; }
        [ForeignKey(nameof(CampusId))]
        public Campus Campus { get; set; }
        [Required]
        public List<Steps> Steps { get; set; }
        [Required]
        [EnumDataType(typeof(Category))]
        public string Category { get; set; } 
    }
    public enum Category
    {
        senior,
        newcomer
    }

}
