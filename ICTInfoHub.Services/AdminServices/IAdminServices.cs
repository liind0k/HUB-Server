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
        

        

    }
}
