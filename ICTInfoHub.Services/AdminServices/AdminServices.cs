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

        public AdminServices(AdminDbContext context)
        {
            _context = context;
        }

        public bool addAdmin(AddAdminDTO staff)
        {
            
            var admin = _context.Admins.FirstOrDefault(a => a.Email == staff.Email);

            if(admin != null)
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
                    _context.Admins.Add(NewAdmin);
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
            var admin = _context.Admins.Find(createNews.AdminId);
            if (admin != null)
            {
                try
                {
                    var news = new News()
                    {
                        Title = createNews.Title,
                        Description = createNews.Description,
                        Priority = createNews.Priority,
                        Campus = createNews.Campus,
                        Category = createNews.Category,
                        DocFile = createNews.DocFile,
                        CreatedAt = DateTime.UtcNow,

                    };
                    _context.Add<News>(news);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public List<News> getAllNews()
        {
            List<News> list = _context.News.ToList();
            return list;
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
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Email == loginAdmin.email && a.Password == loginAdmin.password);

            if (admin == null) return null;

            return admin;
        }

        public bool updateNews(UpdateNewsDTO updateNews)
        {
            var News = _context.News.Find(updateNews.NewsId);

            if(News == null)
            {
                return false;
            }
            else
            {
                try 
                {
                    News.Title = updateNews.Title;
                    News.Description = updateNews.Description;
                    News.Campus = updateNews.Campus;
                    News.Category = updateNews.Category;
                    News.Priority = updateNews.Priority;
                    _context.Update(News);
                    _context.SaveChanges();
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

        public bool deleteNews(DeleteNewsDto deleteNews)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Id == deleteNews.AdminId && a.Password == deleteNews.password);
            if (admin != null)
            {

                var News = _context.News.Find(deleteNews.NewsId);
                if (News == null)
                {
                    return false;
                }
                else
                {
                    _context.News.Remove(News);
                    _context.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
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

        public bool updateDetails(UpdateDetailsDTO updateDetails)
        {
            var admin = _context.Admins.Find(updateDetails.AdminId);

            if(admin == null)
            {
                return false;
            }
            else
            {
                try
                {
                    admin.Surname = updateDetails.Surname;
                    admin.Initials = updateDetails.Initials;
                    _context.Update(admin);
                    _context.SaveChanges();
                    return true;
                }catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool updatePassword(UpdatePasswordDTO updatePassword)
        {
            var Admin = _context.Admins.Find(updatePassword.Id);

            if(Admin == null)
            {
                return false;
            }
            else
            {
                if(Admin.Password == updatePassword.CurrentPassword) 
                {
                    Admin.Password = updatePassword.Password;
                    _context.Update(Admin);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }

        public bool updateEmail(UpdateEmailDTO updateEmail)
        {
            var admin = _context.Admins.Find(updateEmail.Id);

            if(admin == null)
            {
                return false;
            }
            else
            {
                admin.Email = updateEmail.Email;
                _context.Update(admin);
                _context.SaveChanges(); 
                return true;
            }
        }
    }
}
