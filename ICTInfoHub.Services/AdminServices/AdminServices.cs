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

        public bool addAdmin(Admin staff)
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

        public Task<Service> updateServiceContact()
        {
            throw new NotImplementedException();
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

    }
}
