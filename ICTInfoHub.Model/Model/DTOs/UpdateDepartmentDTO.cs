using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Model.Model.DTOs
{
    public class UpdateDepartmentDTO
    {
        public int DepartmentId { get; set; }
        public int CampusId { get; set; }
        public string InputString { get; set; }
    }
}
