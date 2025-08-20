using ICTInfoHub.Model.Model.DTOs;
using ICTInfoHub.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Services.ServiceServices
{
    public interface IServiceServes
    {
        public Task<List<Service>> getServicesByCategory(string category);
        Task<List<Service>> getAllServices();
        Task updateServiceContact(UpdateServiceContactsDTO serviceContactsDTO);
        Task updateServiceSteps(UpdateStepsDTO updateStepsDTO);
    }
}
