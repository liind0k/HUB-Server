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
    public class Steps
    {
        [Key]
        public int StepId { get; set; }
        public string StepsTitle { get; set; }
        public string StepsDescription { get; set; }
        public int CampusServiceId { get; set; }
        [ForeignKey(nameof(CampusServiceId))]
        [JsonIgnore]
        public CampusService? CampusService { get; set; }


    }
}
