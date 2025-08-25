using ICTInfoHub.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Services.CampusServices
{
    public class CampusServices : ICampusServices
    {
        AdminDbContext _adminDbContext;

        public CampusServices(AdminDbContext adminDbContext)
        {
            _adminDbContext = adminDbContext;
        }

        public async Task<Campus> getCampus(int CampusId)
        {
            return await _adminDbContext.Campuses
                .Include(c => c.News)
                .Include(c => c.Services)
                .Include(c => c.Departments)
                .FirstOrDefaultAsync(c => c.CampusId == CampusId);
        }

        public async Task<List<Campus>> getCampusList()
        {
            return await _adminDbContext.Campuses
                .Include(c => c.News)
                .Include(c => c.Services)
                .Include(c => c.Departments)
                .ToListAsync();
        }
    }
}
