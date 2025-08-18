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
        bool addNews(CreateNewsDTO createNewsDTO);
        bool updateNews(UpdateNewsDTO updateNewsDTO);
        bool addAdmin(Admin staff);
        Task<List<Service>> getAllServices();        
        Task<Service> updateServiceContact();
        

    }
}
