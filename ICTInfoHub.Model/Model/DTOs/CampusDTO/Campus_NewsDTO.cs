using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ICTInfoHub.Model.Model.DTOs.CampusDTO
{
    public class Campus_NewsDTO
    {
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDescription { get; set; }
        public string Priority { get; set; }
        public string Category { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte[]? DocFile { get; set; }

    }
}
