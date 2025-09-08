using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Model.Model.DTOs
{
    public class UpdateServiceContactsDTO
    {
        public int ServiceId { get; set; }
        public int CampusId { get; set; }
        public string inputString { get; set; }
    }
}
