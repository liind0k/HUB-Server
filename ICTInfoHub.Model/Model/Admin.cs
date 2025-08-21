using System.ComponentModel.DataAnnotations;

namespace ICTInfoHub.Model.Model
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        
        public string Initials { get; set; } = string.Empty;
        
        public string Surname { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<News> News { get; set; } = new List<News>();

    }
}
