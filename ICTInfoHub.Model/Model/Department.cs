using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ICTInfoHub.Model.Model
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int CampusId { get; set; }
        [ForeignKey(nameof(CampusId))]
        [JsonIgnore]
        public Campus Campus { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();  
    }
}
