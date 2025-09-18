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
    public class CampusDepartment
    {
        [Key]
        public int CampusDepartmentId {  get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DepartmentLocation { get; set; }
        public int DepartmentId { get; set;}
        [ForeignKey(nameof(DepartmentId))]
        [JsonIgnore]
        public Department Department { get; set; }
        public int CampusId { get; set; }
        [ForeignKey(nameof(CampusId))]
        [JsonIgnore]
        public Campus Campus { get;}
        
    }
}
