using System.ComponentModel.DataAnnotations;

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

        public List<string> Steps { get; set; }

        public string Category { get; set; } 
    }
    public enum Category
    {
        all,
        senior,
        newcomer
    }
}
