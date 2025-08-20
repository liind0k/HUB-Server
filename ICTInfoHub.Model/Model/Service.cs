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
        [EnumDataType(typeof(Campus))]
        public string Campus { get; set; }
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
