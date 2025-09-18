using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Model.Model.DTOs.CampusDTO
{
    public class CampusDepartmentDTO
    {
        public int CampusDepartmentId { get; set; }
        public DepartmentDTO department { get; set; }
    }
}
