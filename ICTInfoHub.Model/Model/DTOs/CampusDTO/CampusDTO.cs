using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Model.Model.DTOs.CampusDTO
{
    public class CampusDTO
    {
        public int CampusId { get; set; }
        public string CampusName { get; set; }
        public ICollection<Campus_NewsDTO> News { get; set; } = new List<Campus_NewsDTO>();
        public ICollection<ServiceDTO> Services { get; set; } = new List<ServiceDTO>();
        public ICollection<DepartmentDTO> Departments { get; set; } = new List<DepartmentDTO>();
    }
}
