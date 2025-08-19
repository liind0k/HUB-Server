using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Model.Model.DTOs
{
    public class DeleteNewsDto
    {
        public int NewsId {  get; set; }
        public string password { get; set;}
        public int AdminId { get; set;}
    }
}
