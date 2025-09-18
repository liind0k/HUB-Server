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
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public int Credits { get; set; }
        public ICollection<Contact>? Contacts {  get; set; } = new List<Contact>();
        [JsonIgnore]
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
