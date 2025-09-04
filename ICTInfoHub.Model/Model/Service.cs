using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


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
        public string ServiceEmail { get; set; }
        public string ServiceLocation { get; set; }
        public string ServicePhone { get; set; }
        public int CampusId { get; set; }
        [ForeignKey(nameof(CampusId))]
        [JsonIgnore]
        public List<Campus> Campus { get; set; }
        [Required]
        public List<Steps> Steps { get; set; }
        [Required]
        [EnumDataType(typeof(Category))]
        public string Category { get; set; } 
    }
    public enum Category
    {
        all,
        senior,
        newcomer
    }

}
