using System.ComponentModel.DataAnnotations;

namespace ICTInfoHub.Model.Model.DTOs.CampusDTO
{
    public class ServiceDTO
    {
        public int ServiceId { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceUrl { get; set; }
        public string Category { get; set; }
    }
}