using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICTInfoHub.Model.Model;
using ICTInfoHub.Model.Model.DTOs;
using ICTInfoHub.Model.Model.DTOs.CampusDTO;

namespace ICTInfoHub.Services.CampusServices
{
    public interface ICampusServices
    {
        Task<CampusDTO> getCampus(int id);
        Task<List<CampusDTO>> getCampusList();
        Task<CampusDTO> adminGetCampus(int id);
        Task<List<CampusDTO>> adminGetCampusList();
    }
}
