using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Model.Model.DTOs
{
    public class GetServiceDTO
    {
        public int CampusId { get; set; }
        public int ServiceId { get; set; }
        public int CampusServiceId { get; set; }
    }
}
