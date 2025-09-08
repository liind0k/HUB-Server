using ICTInfoHub.Model.Model;
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

        public async Task<Campus> adminGetCampus(int CampusId)
        {
            var result = await _adminDbContext.Campuses
                .Where(c => c.CampusId == CampusId)
                .Select(c => new Campus()
                {
                    CampusId = c.CampusId,
                    CampusName = c.CampusName,
                    
                    News = c.News.Select(n => new News()
                    { 
                                NewsId = n.NewsId,
                                NewsTitle = n.NewsTitle,
                                NewsDescription = n.NewsDescription })
                            .ToList(),

                    CampusServices = c.CampusServices.Select(cs => new  CampusService()
                    {
                            CampusServiceId = cs.CampusServiceId, 
                            service = new Service()
                        {
                               ServiceTitle = cs.service.ServiceTitle,
                               ServiceDescription = cs.service.ServiceDescription,
                               ServiceUrl = cs.service.ServiceUrl
                        },
                        Email = cs.Email,
                        Location = cs.Location,
                        Phone = cs.Phone,
                        Steps = cs.Steps.Select(s => new Steps() 
                        {
                            StepId = s.StepId,
                            StepsTitle = s.StepsTitle,
                            StepsDescription = s.StepsDescription,
                        }).ToList()
                    }).ToList(),

                Departments = c.Departments.Select(d => new  Department
                {
                    DepartmentId = d.DepartmentId, 
                    DepartmentName = d.DepartmentName,
                    
                    Courses = d.Courses.Select(c => new Course()
                    {
                        CourseCode = c.CourseCode,
                        CourseName = c.CourseName,
                        NQFLevel = c.NQFLevel,
                        Duration = c.Duration
                    }).ToList()
                }).ToList()
                }).FirstOrDefaultAsync();
                
            return result;


        }

        public async Task<List<Campus>> adminGetCampusList()
        {
            var campuses = await _adminDbContext.Campuses
                .Select(c => new Campus() 
                {
                    CampusId = c.CampusId,
                    CampusName = c.CampusName,

                    News = c.News.Select(n => new News() 
                    {
                        NewsId = n.NewsId,
                        NewsTitle = n.NewsTitle,
                        NewsDescription = n.NewsDescription,
                        Category = n.Category,
                        Priority = n.Priority,
                        CreatedAt = n.CreatedAt,
                    })
                     .ToList(),

                    CampusServices = c.CampusServices.Select(cs => new CampusService()
                    {
                        CampusServiceId = cs.CampusServiceId,
                        service = new Service() 
                        {
                            ServiceTitle = cs.service.ServiceTitle,
                            ServiceDescription = cs.service.ServiceDescription,
                            ServiceUrl = cs.service.ServiceUrl
                        },
                        Email = cs.Email,
                        Location = cs.Location,
                        Phone = cs.Phone,
                        Steps = cs.Steps.Select(s => new Steps()
                        {
                            StepId = s.StepId,
                            StepsTitle = s.StepsTitle,
                            StepsDescription = s.StepsDescription,
                        }).ToList()
                    }).ToList(),

                    Departments = c.Departments.Select(d => new Department()
                    {
                        DepartmentId = d.DepartmentId,
                        DepartmentName = d.DepartmentName,

                        Courses = d.Courses.Select(c => new Course()
                        {
                            CourseCode = c.CourseCode,
                            CourseName = c.CourseName,
                            NQFLevel = c.NQFLevel,
                            Duration = c.Duration
                        }).ToList()
                    }).ToList()
                }).ToListAsync();

            return campuses;
        }
    
        public async Task<Campus> getCampus(int CampusId)
        {
            var result = await _adminDbContext.Campuses
                .Where(c => c.CampusId == CampusId)
                .Select(c => new Campus()
                {
                    CampusId = c.CampusId,
                    CampusName = c.CampusName,

                    News = c.News.Where(n => n.IsVisible).Select(n => new News()
                    {
                        NewsId = n.NewsId,
                        NewsTitle = n.NewsTitle,
                        NewsDescription = n.NewsDescription
                    })
                            .ToList(),

                    CampusServices = c.CampusServices.Select(cs => new CampusService()
                    {
                        CampusServiceId = cs.CampusServiceId,
                        service = new Service()
                        {
                            ServiceTitle = cs.service.ServiceTitle,
                            ServiceDescription = cs.service.ServiceDescription,
                            ServiceUrl = cs.service.ServiceUrl
                        },
                        Email = cs.Email,
                        Location = cs.Location,
                        Phone = cs.Phone,
                        Steps = cs.Steps.Select(s => new Steps()
                        {
                            StepId = s.StepId,
                            StepsTitle = s.StepsTitle,
                            StepsDescription = s.StepsDescription,
                        }).ToList()
                    }).ToList(),

                    Departments = c.Departments.Select(d => new Department()
                    {
                        DepartmentId = d.DepartmentId,
                        DepartmentName = d.DepartmentName,

                        Courses = d.Courses.Select(c => new Course()
                        {
                            CourseCode = c.CourseCode,
                            CourseName = c.CourseName,
                            NQFLevel = c.NQFLevel,
                            Duration = c.Duration
                        }).ToList()
                    }).ToList()
                }).FirstOrDefaultAsync();

            return result;

        }

        public async Task<List<Campus>> getCampusList()
        {
            var result = await _adminDbContext.Campuses
                .Select(c => new Campus()
                {
                    CampusId = c.CampusId,
                    CampusName = c.CampusName,

                    News = c.News.Where(n => n.IsVisible).Select(n => new News()
                    {
                        NewsId = n.NewsId,
                        NewsTitle = n.NewsTitle,
                        NewsDescription = n.NewsDescription
                    })
                            .ToList(),

                    CampusServices = c.CampusServices.Select(cs => new CampusService()
                    {
                        CampusServiceId = cs.CampusServiceId,
                        service = new Service()
                        {
                            ServiceTitle = cs.service.ServiceTitle,
                            ServiceDescription = cs.service.ServiceDescription,
                            ServiceUrl = cs.service.ServiceUrl
                        },
                        Email = cs.Email,
                        Location = cs.Location,
                        Phone = cs.Phone,
                        Steps = cs.Steps.Select(s => new Steps()
                        {
                            StepId = s.StepId,
                            StepsTitle = s.StepsTitle,
                            StepsDescription = s.StepsDescription,
                        }).ToList()
                    }).ToList(),

                    Departments = c.Departments.Select(d => new Department()
                    {
                        DepartmentId = d.DepartmentId,
                        DepartmentName = d.DepartmentName,

                        Courses = d.Courses.Select(c => new Course()
                        {
                            CourseCode = c.CourseCode,
                            CourseName = c.CourseName,
                            NQFLevel = c.NQFLevel,
                            Duration = c.Duration
                        }).ToList()
                    }).ToList()
                }).ToListAsync();

            return result;
        }
    }
}
