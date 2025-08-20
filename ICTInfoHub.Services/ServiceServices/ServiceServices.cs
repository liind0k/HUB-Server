using ICTInfoHub.Model.Model.DTOs;
using ICTInfoHub.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Services.ServiceServices
{
    public class ServiceServices: IServiceServes
    {
        private readonly AdminDbContext _context;

        public ServiceServices(AdminDbContext context)
        {
            _context = context;
        }
        public async Task<List<Service>> getAllServices()
        {
            List<Service> services = _context.Services.ToList();
            return services;
        }
        public async Task<List<Service>> getServicesByCategory(string category)
        {
            var res = await _context.Services.Select(a => a).Where(a => a.Category == category).ToListAsync();

            if (res.Count == 0)
            {
                return null;
            }
            return res;
        }
        public async Task updateServiceContact(UpdateServiceContactsDTO updateContacts)
        {
            var service = _context.Services.Find(updateContacts.Id);

            if (service != null)
            {
                service.Phone = updateContacts.phone;
                service.Email = updateContacts.email;
                service.Location = updateContacts.location;

                _context.Services.Update(service);
                _context.SaveChanges();

            }

        }
        public async Task updateServiceSteps(UpdateStepsDTO updateStepsDTO)
        {
            var service = _context.Services.Find(updateStepsDTO.ServiceId);
            if (service != null)
            {
                service.Steps = updateStepsDTO.Steps;
                _context.Services.Update(service);
                _context.SaveChanges();
            }
        }
    }
}
