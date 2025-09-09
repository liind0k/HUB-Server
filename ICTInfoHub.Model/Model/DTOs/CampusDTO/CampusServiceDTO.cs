using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ICTInfoHub.Model.Model.DTOs.CampusDTO
{
    public class CampusServiceDTO
    {
        public int CampusServiceId { get; set; }
        public ServiceDTO service { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public ICollection<StepsDTO> Steps { get; set; } = new List<StepsDTO>();
    }
}
