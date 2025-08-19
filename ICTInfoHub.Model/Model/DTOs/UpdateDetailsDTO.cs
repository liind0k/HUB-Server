using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Model.Model.DTOs
{
    public class UpdateDetailsDTO
    {
        [Key]
        public int AdminId { get; set; }
        public string Initials { get; set; }
        public string Surname { get; set; }
    }
}
