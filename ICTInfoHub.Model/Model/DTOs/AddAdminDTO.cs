using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Model.Model.DTOs
{
    public class AddAdminDTO
    {
        public string Initials { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
