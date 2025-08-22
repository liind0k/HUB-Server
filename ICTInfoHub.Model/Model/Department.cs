using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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
        public Campus Campus { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();  
    }
}
