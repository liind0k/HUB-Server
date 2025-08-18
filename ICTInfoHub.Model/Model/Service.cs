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
        public string Email { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
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
