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
    public class CampusService
    {
        [Key]
        public int CampusServiceId { get; set; }
        public int CampusId { get; set; }
        [ForeignKey(nameof(CampusId))]
        [JsonIgnore]
        public Campus Campus { get; set; }
        public int ServiceId { get; set; }
        [ForeignKey(nameof(ServiceId))]
        [JsonIgnore]
        public Service service { get; set; }
        public string Phone {  get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public ICollection<Steps> Steps { get; set; }
    }
}
