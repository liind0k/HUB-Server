using ICTInfoHub.Model.Model.DTOs;
using ICTInfoHub.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICTInfoHub.Model.Model.DTOs.CampusDTO;

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
                                                  .ToListAsync();
            return services;
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
        public async Task<bool> updateServiceSteps(Steps IncomeStep)
        {

                var Step = await _context.Steps.FindAsync(IncomeStep.StepId);

                if(Step != null)
                {
                    Step.StepsTitle = IncomeStep.StepsTitle;
                Step.StepsDescription = IncomeStep.StepsDescription;
                    _context.Steps.Update(Step);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }           
        }
        public async Task<CampusServiceDTO> getService(int ServiceId, int CampusId)
        {
            var getCampServ = await _context.Set<CampusService>().FirstOrDefaultAsync(cs => cs.ServiceId== ServiceId && cs.CampusId == CampusId);
            if (getCampServ == null)
                return null;

            var service = await  _context.Set<CampusService>()
                                    .Select(cs => new CampusServiceDTO()
                                    {
                                        CampusServiceId = cs.CampusServiceId,
                                        service = new ServiceDTO()
                                        {
                                            ServiceId = cs.service.ServiceId,
                                            ServiceTitle = cs.service.ServiceTitle,
                                            ServiceDescription = cs.service.ServiceDescription,
                                            ServiceUrl = cs.service.ServiceUrl,
                                        },
                                        Phone = cs.Phone,
                                        Email = cs.Email,
                                        Location = cs.Location,

                                        Steps = cs.Steps.Select(s => new StepsDTO()
                                        {
                                            StepId = s.StepId,
                                            StepsTitle = s.StepsTitle,
                                            StepsDescription = s.StepsDescription,

                                        }).ToList()
                                        
                                    })
                                .FirstOrDefaultAsync(cs => cs.CampusServiceId== getCampServ.CampusServiceId);

            if (service != null)
            {
                return service;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<CampusServiceDTO>> getAllServicesByCampus(int CampusId)
        {
            var service = await _context.Set<CampusService>()
                            .Where(cs => cs.CampusId == CampusId)
                            .Select(cs => new CampusServiceDTO()
                            {
                                CampusServiceId = cs.CampusServiceId,
                                service = new ServiceDTO()
                                {
                                    ServiceId = cs.service.ServiceId,
                                    ServiceTitle = cs.service.ServiceTitle,
                                    ServiceDescription = cs.service.ServiceDescription,
                                    ServiceUrl = cs.service.ServiceUrl,
                                },
                                Phone = cs.Phone,
                                Email = cs.Email,
                                Location = cs.Location,

                                Steps = cs.Steps.Select(s => new StepsDTO()
                                {
                                    StepId = s.StepId,
                                    StepsTitle  = s.StepsTitle,
                                    StepsDescription = s.StepsDescription,

                                }).ToList()

                            }).ToListAsync();
            return service;
        }
    }
}
