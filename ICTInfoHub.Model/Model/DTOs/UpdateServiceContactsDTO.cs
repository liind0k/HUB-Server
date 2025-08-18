using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Model.Model.DTOs
{
    public class UpdateServiceContactsDTO
    {
        public int Id { get; set; }
        public string phone { get; set; }
        public string location { get; set; }
        public string email { get; set; }
    }
}
