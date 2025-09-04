using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ICTInfoHub.Model.Model
{
    public class Campus
    {
        [Key]
        public int CampusId { get; set; }

        [MaxLength(100)]
        public string CampusName { get; set; }

        public ICollection<News> News { get; set; } = new List<News>();

        public ICollection<Service> Services { get; set; } = new List<Service>();
        
        public ICollection<Department> Departments { get; set; }   = new List<Department>();

    }
}
