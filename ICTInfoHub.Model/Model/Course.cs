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
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Duration { get; set; }
        public string NQFLevel { get; set; }
        public ICollection<Module>? Modules { get; set; } = new List<Module>();
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [JsonIgnore]
        public Department Department { get; set; } 
    }
}
