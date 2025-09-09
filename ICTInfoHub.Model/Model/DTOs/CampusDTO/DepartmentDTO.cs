using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ICTInfoHub.Model.Model.DTOs.CampusDTO
{
    public class DepartmentDTO
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
    }
}
