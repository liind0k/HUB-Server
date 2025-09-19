using ICTInfoHub.Model.Model;
using ICTInfoHub.Model.Model.DTOs.CampusDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Services.CampusServices
{
    public class CampusServices : ICampusServices
    {
        AdminDbContext _adminDbContext;

        public CampusServices(AdminDbContext adminDbContext)
        {
            _adminDbContext = adminDbContext;
        }
        public async Task<CampusDTO> adminGetCampus(int CampusId)
        {
            var result = await _adminDbContext.Campuses
                .Where(c => c.CampusId == CampusId)
                .Select(c => new CampusDTO()
                {
                    CampusId = c.CampusId,
                    CampusName = c.CampusName,
                    
                    News = c.News.Select(n => new Campus_NewsDTO()
                    {
                        NewsId = n.NewsId,
                        NewsTitle = n.NewsTitle,
                        NewsDescription = n.NewsDescription,
                        Category = n.Category,
                        Priority = n.Priority,
                        DocFile = n.DocFile,
                        CreatedAt = n.CreatedAt
                    })
                     .ToList(),

                    Services = c.CampusServices.Select(cs => new  ServiceDTO()
                    {
                        
                            ServiceId = cs.service.ServiceId,
                            ServiceTitle = cs.service.ServiceTitle,
                            ServiceDescription = cs.service.ServiceDescription,
                            ServiceUrl = cs.service.ServiceUrl,
                            Category = cs.service.Category,
                            Email = cs.Email,
                            Location = cs.Location,
                            Phone = cs.Phone,
                            Steps = cs.Steps.Select(s => new StepsDTO()
                            {
                                StepId = s.StepId,
                                StepsTitle = s.StepsTitle,
                                StepsDescription = s.StepsDescription,
                            }).ToList(),
                            
                    }).ToList(),

                Departments = c.CampusDepartments.Select(d => new DepartmentDTO()
                {
                    
                        DepartmentId = d.Department.DepartmentId,
                        DepartmentName = d.Department.DepartmentName,
                        PhoneNumber = d.PhoneNumber,
                        Email = d.Email,
                        DepartmentLocation = d.DepartmentLocation,
                        Courses =d.Department.Courses.Select(cr => new CourseDTO()
                        {
                            CourseCode = cr.CourseCode,
                            CourseName = cr.CourseName,
                            NQFLevel = cr.NQFLevel,
                            Duration = cr.Duration
                        }).ToList()
                    

                }).ToList()
                }).FirstOrDefaultAsync();
                
            return result;


        }
        public async Task<List<CampusDTO>> adminGetCampusList()
        {
            var campuses = await _adminDbContext.Campuses
                .Select(c => new CampusDTO()
                {
                    CampusId = c.CampusId,
                    CampusName = c.CampusName,

                    News = c.News.Select(n => new Campus_NewsDTO()
                    {
                        NewsId = n.NewsId,
                        NewsTitle = n.NewsTitle,
                        NewsDescription = n.NewsDescription,
                        Category = n.Category,
                        Priority = n.Priority,
                        DocFile = n.DocFile,
                        CreatedAt = n.CreatedAt
                    })
                     .ToList(),

                    Services = c.CampusServices.Select(cs => new ServiceDTO()
                    {
                        
                            ServiceId = cs.service.ServiceId,
                            ServiceTitle = cs.service.ServiceTitle,
                            ServiceDescription = cs.service.ServiceDescription,
                            ServiceUrl = cs.service.ServiceUrl,
                            Category = cs.service.Category,
                            Email = cs.Email,
                            Location = cs.Location,
                            Phone = cs.Phone,
                            Steps = cs.Steps.Select(s => new StepsDTO()
                            {
                                StepId = s.StepId,
                                StepsTitle = s.StepsTitle,
                                StepsDescription = s.StepsDescription,
                            }).ToList()
                        
                    }).ToList(),

                    Departments = c.CampusDepartments.Select(d => new DepartmentDTO()
                    {
                        
                            DepartmentId = d.Department.DepartmentId,
                            DepartmentName = d.Department.DepartmentName,
                            PhoneNumber = d.PhoneNumber,
                            Email = d.Email,
                            DepartmentLocation = d.DepartmentLocation,
                            Courses = d.Department.Courses.Select(cr => new CourseDTO()
                            {
                                CourseCode = cr.CourseCode,
                                CourseName = cr.CourseName,
                                NQFLevel = cr.NQFLevel,
                                Duration = cr.Duration
                            }).ToList()
                        ,
                        
                        

                    }).ToList()
                }).ToListAsync();

            return campuses;
        }
        public async Task<CampusDTO> getCampus(int CampusId)
        {
            var result = await _adminDbContext.Campuses
                .Where(c => c.CampusId == CampusId)
                .Select(c => new CampusDTO()
                {
                    CampusId = c.CampusId,
                    CampusName = c.CampusName,

                    News = c.News.Where(n => n.IsVisible).Select(n => new Campus_NewsDTO()
                    {
                        NewsId = n.NewsId,
                        NewsTitle = n.NewsTitle,
                        NewsDescription = n.NewsDescription,
                        Category = n.Category,
                        Priority = n.Priority,
                        DocFile = n.DocFile,
                        CreatedAt = n.CreatedAt
                    })
                     .ToList(),

                    Services = c.CampusServices.Select(cs => new ServiceDTO()
                    {
                        
                            ServiceId = cs.service.ServiceId,
                            ServiceTitle = cs.service.ServiceTitle,
                            ServiceDescription = cs.service.ServiceDescription,
                            ServiceUrl = cs.service.ServiceUrl,
                            Category = cs.service.Category,
                            Email = cs.Email,
                            Location = cs.Location,
                            Phone = cs.Phone,
                            Steps = cs.Steps.Select(s => new StepsDTO()
                            {
                                StepId = s.StepId,
                                StepsTitle = s.StepsTitle,
                                StepsDescription = s.StepsDescription,
                            }).ToList()
                        
                    }).ToList(),

                    Departments = c.CampusDepartments.Select(d => new DepartmentDTO()
                    {
                            DepartmentId = d.Department.DepartmentId,
                            DepartmentName = d.Department.DepartmentName,
                            PhoneNumber = d.PhoneNumber,
                            Email = d.Email,
                            DepartmentLocation = d.DepartmentLocation,
                            Courses = d.Department.Courses.Select(cr => new CourseDTO()
                            {
                                CourseCode = cr.CourseCode,
                                CourseName = cr.CourseName,
                                NQFLevel = cr.NQFLevel,
                                Duration = cr.Duration
                            }).ToList(),
                    }).ToList()
                }).FirstOrDefaultAsync();

            return result;

        }
        public async Task<List<CampusDTO>> getCampusList()
        {
            var result = await _adminDbContext.Campuses
                .Select(c => new CampusDTO()
                {
                    CampusId = c.CampusId,
                    CampusName = c.CampusName,

                    News = c.News.Where(n => n.IsVisible).Select(n => new Campus_NewsDTO()
                    {
                        NewsId = n.NewsId,
                        NewsTitle = n.NewsTitle,
                        NewsDescription = n.NewsDescription,
                        Category = n.Category,
                        Priority = n.Priority,
                        DocFile = n.DocFile,
                        CreatedAt = n.CreatedAt
                    })
                     .ToList(),

                    Services = c.CampusServices.Select(cs => new ServiceDTO()
                    {
                        
                            ServiceId = cs.service.ServiceId,
                            ServiceTitle = cs.service.ServiceTitle,
                            ServiceDescription = cs.service.ServiceDescription,
                            ServiceUrl = cs.service.ServiceUrl,
                            Category = cs.service.Category,
                            Email = cs.Email,
                            Location = cs.Location,
                            Phone = cs.Phone,
                            Steps = cs.Steps.Select(s => new StepsDTO()
                            {
                                StepId = s.StepId,
                                StepsTitle = s.StepsTitle,
                                StepsDescription = s.StepsDescription,
                            }).ToList()
                        
                    }).ToList(),

                    Departments = c.CampusDepartments.Select(d => new DepartmentDTO()
                    {
                            DepartmentId = d.Department.DepartmentId,
                            DepartmentName = d.Department.DepartmentName,
                            PhoneNumber = d.PhoneNumber,
                            Email = d.Email,
                            DepartmentLocation = d.DepartmentLocation,
                            Courses = d.Department.Courses.Select(cr => new CourseDTO()
                            {
                                CourseCode = cr.CourseCode,
                                CourseName = cr.CourseName,
                                NQFLevel = cr.NQFLevel,
                                Duration = cr.Duration
                            }).ToList(),
                    }).ToList()
                }).ToListAsync();

            return result;
        }
    }
}
