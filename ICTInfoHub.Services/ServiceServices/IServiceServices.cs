using ICTInfoHub.Model.Model.DTOs;
using ICTInfoHub.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ICTInfoHub.Model.Model.DTOs.CampusDTO;

namespace ICTInfoHub.Services.ServiceServices
{
    public interface IServiceServices
    {
        Task<List<Service>> getAllServices();
        Task<List<CampusServiceDTO>> getAllServicesByCampus(int CampusId);
        Task<CampusServiceDTO> getService(int Serviceid, int CampusId);
        Task<bool> updateServicePhone(UpdateServiceContactsDTO serviceContactsDTO);
        Task<bool> updateServiceEmail(UpdateServiceContactsDTO serviceContactsDTO);
        Task<bool> updateServiceLocation(UpdateServiceContactsDTO serviceContactsDTO);
        Task<bool> updateServiceSteps(Steps Steps);
    }
}
