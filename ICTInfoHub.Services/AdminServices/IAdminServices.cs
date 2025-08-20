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
        Task<bool> addAdmin(AddAdminDTO staff);
        Task<bool> updateDetails(UpdateDetailsDTO updateDetails);
        Task<bool> updatePassword(UpdatePasswordDTO updatePassword);
        Task<bool> updateEmail(UpdateEmailDTO updateEmail);       
        

        

    }
}
