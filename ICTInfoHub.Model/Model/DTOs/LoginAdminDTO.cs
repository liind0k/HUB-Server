using System.ComponentModel.DataAnnotations;

namespace ICTInfoHub.Model.Model.DTOs
{
    public class LoginAdminDTO
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}
