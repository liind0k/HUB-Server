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
    public class ServiceServices: IServiceServices
    {
        private readonly AdminDbContext _context;

        public ServiceServices(AdminDbContext context)
        {
            _context = context;
        }
        public async Task<List<Service>> getAllServices()
        {
            List<Service> services = await _context.Services.Include(s => s.Steps).ToListAsync();
            return services;
        }
        public async Task<List<Service>> getServicesByCampus(int campusId)
        {
            var services =  await _context.Services.Select(a => a).Where(a => a.CampusId == campusId).ToListAsync();
            return services;
        }
        public async Task<List<Service>> getServicesByCampusAndCategory(int campusId, string category)
        {
            var services = await _context.Services.Select(a=>a).Where(a=>a.CampusId == campusId && a.Category == category).ToListAsync();
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
        public async Task<bool> updateServicePhone(UpdateServiceContactsDTO updateContacts)
        {
            var service = await _context.Services.FindAsync(updateContacts.Id);

            if (service != null)
            {
                service.ServicePhone = updateContacts.inputString;
                _context.Services.Update(service);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;  
            }

        }
        public async Task<bool> updateServiceEmail(UpdateServiceContactsDTO updateContacts)
        {
            var service = await _context.Services.FindAsync(updateContacts.Id);

            if (service != null)
            {
                service.ServicePhone = updateContacts.inputString;
                _context.Services.Update(service);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }
        public async Task<bool> updateServiceLocation(UpdateServiceContactsDTO updateContacts)
        {
            var service = await _context.Services.FindAsync(updateContacts.Id);

            if (service != null)
            {
                service.ServicePhone = updateContacts.inputString;
                _context.Services.Update(service);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }
        public async Task<bool> updateServiceSteps(UpdateStepsDTO updateStepsDTO)
        {
            var service = _context.Services.Find(updateStepsDTO.ServiceId);
            if (service != null)
            {
                Steps step = updateStepsDTO.Step;
                var findStep = await _context.Steps.FindAsync(step.StepId);

                if(findStep != null)
                {
                    findStep.StepsTitle = step.StepsTitle;
                    findStep.StepsDescription = step.StepsDescription;
                    await _context.Services.FindAsync(step.StepId);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
        public async Task<Service> getService(int id)
        {
            var service = await  _context.Services
                                .Include(s => s.Steps)
                                .FirstOrDefaultAsync(s => s.ServiceId==id);

            if (service != null)
            {
                return service;
            }
            else
            {
                return null;
            }
        }
    }
}
