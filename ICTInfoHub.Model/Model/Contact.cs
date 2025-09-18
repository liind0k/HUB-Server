using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ICTInfoHub.Model.Model
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string? OfficeNumber { get; set; }
        [JsonIgnore]
        public ICollection<Module> Modules { get; set; } = new List<Module>();
    }
}