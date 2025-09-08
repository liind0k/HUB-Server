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
        [Required]
        [EnumDataType(typeof(Category))]
        public string Category { get; set; }
        public ICollection<CampusService> CampusServices { get; set; } = new List<CampusService>();
    }
    public enum Category
    {
        all,
        senior,
        newcomer
    }

}
