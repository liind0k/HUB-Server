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
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DepartmentLocation { get; set; }
        public ICollection<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
    }
}
