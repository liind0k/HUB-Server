using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICTInfoHub.Model.Model;
using ICTInfoHub.Model.Model.DTOs;

namespace ICTInfoHub.Services.CampusServices
{
    public interface ICampusServices
    {
        Task<Campus> getCampus(int id);
        Task<List<Campus>> getCampusList();
        Task<Campus> adminGetCampus(int id);
        Task<List<Campus>> adminGetCampusList();
    }
}
