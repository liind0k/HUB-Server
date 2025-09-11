using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Model.Model.DTOs.NewsDTO
{
    public class NewsDTO
    {
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDescription { get; set; }
        public string Priority { get; set; }
        public string Category { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte[]? DocFile { get; set; }

        public List<News_CampusDTO> news_Campus { get; set; }
    }
}
