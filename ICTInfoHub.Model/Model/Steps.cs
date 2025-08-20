using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Model.Model
{
    public class Steps
    {
        [Key]
        public int StepId { get; set; }

     public Service service { get; set; }
        public int ServiceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string OfficeNumber { get; set; }
        public string url { get; set;}

    }
}
