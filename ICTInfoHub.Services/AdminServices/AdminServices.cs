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
        public async Task<bool> addAdmin(AddAdminDTO staff)
        {
            
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Email == staff.Email);

            if(admin != null)
            {
                throw new Exception("User already exist.");
            }
            else
            {
                    var NewAdmin = new Admin()
                    {
                        Email = staff.Email,
                        Surname = staff.Surname,
                        Initials = staff.Initials,
                        Password = staff.Password,
                    };
                    _context.Admins.Add(NewAdmin);
                    await _context.SaveChangesAsync();
                    return true;

            }

        }
        public async Task<Admin> loginAsync(LoginAdminDTO loginAdmin)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Email == loginAdmin.email && a.Password == loginAdmin.password);

            if (admin == null)
                throw new Exception("User not found.");

            return admin;
        }
        public async Task<bool> updateDetails(UpdateDetailsDTO updateDetails)
        {
            var admin = await _context.Admins.FindAsync(updateDetails.AdminId);

            if(admin == null)
            {
                throw new Exception("User not found.");
            }
            else
            {
                    admin.Surname = updateDetails.Surname;
                    admin.Initials = updateDetails.Initials;
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                    return true;
            }
        }
        public async Task<bool> updatePassword(UpdatePasswordDTO updatePassword)
        {
            var Admin = await _context.Admins.FindAsync(updatePassword.Id);

            if(Admin == null)
            {
                throw new Exception("User not found.");
            }
            else
            {
                if(Admin.Password == updatePassword.CurrentPassword) 
                {
                    Admin.Password = updatePassword.Password;
                    _context.Update(Admin);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new Exception("Current Password is incorrect.");
                }
                
            }
        }
        public async Task<bool> updateEmail(UpdateEmailDTO updateEmail)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Id == updateEmail.Id);

            if(admin == null)
            {
                throw new Exception("User not found.");
            }
            else
            {
                admin.Email = updateEmail.Email;
                _context.Update(admin);
                await _context.SaveChangesAsync(); 
                return true;
            }
        }
    }
}
