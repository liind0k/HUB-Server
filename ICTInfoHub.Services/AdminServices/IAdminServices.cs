using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICTInfoHub.Model;
using ICTInfoHub.Model.Model;
using ICTInfoHub.Model.Model.DTOs;

namespace ICTInfoHub.Services.AdminServices
{
    public interface IAdminServices
    {
        Task<Admin> loginAsync(LoginAdminDTO loginAdmin);
        bool addAdmin(AddAdminDTO staff);
        bool addNews(CreateNewsDTO createNewsDTO);
        bool updateNews(UpdateNewsDTO updateNewsDTO);
        Task<List<News>> getNewsByCampus(string Campus);
        bool tagCampus(TagCampusDTO tagCampusDTO);
        bool deleteNews(int  id);
        Task<List<Service>> getAllServices();        
        Task updateServiceContact(UpdateServiceContactsDTO serviceContactsDTO);
        Task updateServiceSteps(UpdateStepsDTO updateStepsDTO);
        

    }
}
