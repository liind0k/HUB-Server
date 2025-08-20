using ICTInfoHub.Model.Model;
using ICTInfoHub.Model.Model.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
        public async Task<Admin> loginAsync(LoginAdminDTO loginAdmin)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Email == loginAdmin.email && a.Password == loginAdmin.password);

            if (admin == null) return null;

            return admin;
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
