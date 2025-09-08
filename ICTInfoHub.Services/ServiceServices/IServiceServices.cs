using ICTInfoHub.Model.Model.DTOs;
using ICTInfoHub.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ICTInfoHub.Services.ServiceServices
{
    public interface IServiceServices
    {
        public Task<List<Service>> getServicesByCategory([EnumDataType(typeof(Category))]string category);
        Task<List<Service>> getAllServices();
        Task<Service> getService(int id);
        Task<List<CampusService>> getServicesByCampus(int campusId);
        Task<bool> updateServicePhone(UpdateServiceContactsDTO serviceContactsDTO);
        Task<bool> updateServiceEmail(UpdateServiceContactsDTO serviceContactsDTO);
        Task<bool> updateServiceLocation(UpdateServiceContactsDTO serviceContactsDTO);
        Task<bool> updateServiceSteps(UpdateStepsDTO updateStepsDTO);
    }
}
