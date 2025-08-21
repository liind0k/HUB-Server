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
    public interface IServiceServes
    {
        public Task<List<Service>> getServicesByCategory([EnumDataType(typeof(Category))]string category);
        Task<List<Service>> getAllServices();
        Task<List<Service>> getServicesByCampus(int campusId);
        Task<List<Service>> getServicesByCampusAndCategory(int campusId,string category);
        Task updateServiceContact(UpdateServiceContactsDTO serviceContactsDTO);
        Task updateServiceSteps(UpdateStepsDTO updateStepsDTO);
    }
}
