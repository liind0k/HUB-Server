using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICTInfoHub.Model;
using ICTInfoHub.Model.Model;
using ICTInfoHub.Model.Model.DTOs;
using Microsoft.AspNetCore.Http;

namespace ICTInfoHub.Services.AdminServices
{
    public interface IAdminServices
    {
        Task<Admin> loginAsync(LoginAdminDTO loginAdmin);
        bool addAdmin(AddAdminDTO staff);
        bool updateDetails(UpdateDetailsDTO updateDetails);
        bool updatePassword(UpdatePasswordDTO updatePassword);
        bool updateEmail(UpdateEmailDTO updateEmail);       
        List<News> getAllNews();
        Task<bool> addNews(CreateNewsDTO createNewsDTO);
        Task<bool> updateNews(UpdateNewsDTO updateNewsDTO);
        Task<List<News>> getNewsByCampus(string Campus);
        bool tagCampus(TagCampusDTO tagCampusDTO);
        bool deleteNews(DeleteNewsDto deleteNews);
        public Task<List<Service>> getServicesByCategory(string category);
        Task<List<Service>> getAllServices();        
        Task updateServiceContact(UpdateServiceContactsDTO serviceContactsDTO);
        Task updateServiceSteps(UpdateStepsDTO updateStepsDTO);
        

    }
}
