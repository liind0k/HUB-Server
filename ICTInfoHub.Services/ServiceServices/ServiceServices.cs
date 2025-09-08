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
            List<Service> services = await _context.Services
                                                .Include(s => s.CampusServices)
                                                    .ThenInclude(cs => cs.Phone)
                                                .Include(s => s.CampusServices)
                                                    .ThenInclude(cs => cs.Email)
                                                .Include(s => s.CampusServices)
                                                    .ThenInclude(cs => cs.Location)
                                                .Include(s => s.CampusServices)
                                                    .ThenInclude(cs => cs.Steps)
                                                  .ToListAsync();
            return services;
        }
        public async Task<List<CampusService>> getServicesByCampus(int campusId)
        {
            var services =  await _context.Set<CampusService>().Select(a => a).Where(a => a.CampusId == campusId)
                        .Include(cs => cs.Campus)
                           .ThenInclude(c => c.CampusName)
                        .Include(cs => cs.service)
                           .ThenInclude(s => s.ServiceTitle)
                        .Include(cs => cs.service)
                           .ThenInclude(s => s.ServiceUrl)
                        .Include(cs => cs.Phone)
                        .Include(cs => cs.Email)
                        .Include(cs => cs.Location)
                        .Include(cs => cs.Steps)
                        .ToListAsync();
            return services;
        }
        public async Task<List<Service>> getServicesByCategory(string category)
        {
            var res = await _context.Services.Select(a => a).Where(a => a.Category == category)
                                    .Include(s => s.CampusServices)
                                        .ThenInclude(cs => cs.Phone)
                                    .Include(s => s.CampusServices)
                                        .ThenInclude(cs => cs.Email)
                                    .Include(s => s.CampusServices)
                                        .ThenInclude(cs => cs.Location)
                                    .Include(s => s.CampusServices)
                                        .ThenInclude(cs => cs.Steps)
                                    .ToListAsync();

            if (res.Count == 0)
            {
                return null;
            }
            return res;
        }
        public async Task<bool> updateServicePhone(UpdateServiceContactsDTO updateContacts)
        {
            var service = await _context.Set<CampusService>().FirstOrDefaultAsync(a => a.CampusId == updateContacts.CampusId && a.ServiceId == a.ServiceId);

            if (service != null)
            {
             
                service.Phone = updateContacts.inputString;
                _context.Set<CampusService>().Update(service);
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
            var service = await _context.Set<CampusService>().FirstOrDefaultAsync(a => a.CampusId == updateContacts.CampusId && a.ServiceId == a.ServiceId);

            if (service != null)
            {

                service.Email = updateContacts.inputString;
                _context.Set<CampusService>().Update(service);
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
            var service = await _context.Set<CampusService>().FirstOrDefaultAsync(a => a.CampusId == updateContacts.CampusId && a.ServiceId == a.ServiceId);

            if (service != null)
            {

                service.Location = updateContacts.inputString;
                _context.Set<CampusService>().Update(service);
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
                                .Include(s => s.CampusServices)
                                    .ThenInclude(cs => cs.Phone)
                                .Include(s => s.CampusServices)
                                    .ThenInclude(cs => cs.Email)
                                .Include(s => s.CampusServices)
                                    .ThenInclude(cs => cs.Location)
                                .Include(s => s.CampusServices)
                                    .ThenInclude(cs => cs.Steps)
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
