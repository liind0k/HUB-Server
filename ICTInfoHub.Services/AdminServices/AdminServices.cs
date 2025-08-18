using ICTInfoHub.Model.Model;
using ICTInfoHub.Model.Model.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Services.AdminServices
{
    public class AdminServices : IAdminServices
    {
        private readonly AdminDbContext _context;

        public bool addAdmin(AddAdminDTO staff)
        {
            
            var admin = _context.Admins.FirstOrDefault(a => a.Email == staff.Email);

            if(admin == null)
            {
                return false;
            }
            else
            {
                try
                {
                    var NewAdmin = new Admin()
                    {
                        Email = staff.Email,
                        Surname = staff.Surname,
                        Initials = staff.Initials,
                        Password = staff.Password,
                    };
                    _context.Admins.Add(admin);
                    _context.SaveChanges();
                    return true;
                }catch (Exception ex)
                {
                    return false;
                }
            }

        }

        public bool addNews(CreateNewsDTO createNews)
        {
            try
            {
                var news = new News()
                            {
                                Title = createNews.Title,
                                Description = createNews.Description,
                                Priority = createNews.Priority,
                                Campus = createNews.Priority,
                                Category = createNews.Category,
                                DocFile = createNews.DocFile,
                                CreatedAt = createNews.CreatedDate, 

                            };
                _context.Add<News>(news);
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<List<Service>> getAllServices()
        {
            List<Service> services =  _context.Services.ToList();
            return services;
        }

        public async Task updateServiceContact(UpdateServiceContactsDTO updateContacts)
        {
            var service =  _context.Services.Find(updateContacts.Id);

            if (service != null)
            {
                service.Phone = updateContacts.phone;
                service.Email = updateContacts.email;
                service.Location = updateContacts.location;

                _context.Services.Update(service);
                _context.SaveChanges();

            }
        
        }

        public async Task<Admin> loginAsync(LoginAdminDTO loginAdmin)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Email == loginAdmin.email);

            if (admin == null) return null;

            return admin;
        }

        public bool updateNews(UpdateNewsDTO updateNewsDTO)
        {
            var News = _context.News.FirstOrDefaultAsync(a => a.Id == updateNewsDTO.NewsId);

            if(News == null)
            {
                return true;
            }
            else
            {
                try 
                {
                    var NewNews = new News()
                    {
                        Id = updateNewsDTO.NewsId,
                        Title = updateNewsDTO.Title,
                        Description = updateNewsDTO.Description,
                        Priority = updateNewsDTO.Priority,
                        Campus = updateNewsDTO.Campus,
                        Category = updateNewsDTO.Category,
                        DocFile = updateNewsDTO.DocFile,
                    };
                    return true;
                }catch (Exception ex)
                {
                    return false;
                }

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

        public bool deleteNews(int id)
        {
            var News = _context.News.Find(id);
            if (News == null) 
            { 
                return false; 
            }else
            {
                _context.News.Remove(News);
                _context.SaveChanges();
                return true;
            }
        }

        public async Task<List<News>> getNewsByCampus(string Campus)
        {
            List<News> News =  await _context.News.Select(a => a).Where(a => a.Campus == Campus).ToListAsync();
            return News;
        }

        public bool tagCampus(TagCampusDTO tagCampusDTO)
        {
            var News = _context.News.Find(tagCampusDTO.newsId);

            if(News == null)
            {
                return false;
            }
            else
            {
                News.Campus = tagCampusDTO.campus;
                _context.Update(News);
                _context.SaveChanges();
          
                return true;
            }
        }
    }
}
