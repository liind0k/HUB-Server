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

        public async Task<Campus> adminGetCampus(int CampusId)
        {
            var result = await _adminDbContext.Campuses
                .Include(c => c.News)
                .Include(c => c.Services)
                    .ThenInclude(s => s.Steps)
                .Include(c => c.Departments)
                    .ThenInclude(d => d.Courses)
                .FirstOrDefaultAsync(c => c.CampusId == CampusId);
            return result;


        }

        public async Task<List<Campus>> adminGetCampusList()
        {
            return await _adminDbContext.Campuses
                .Include(c => c.News)
                .Include(c => c.Services)
                    .ThenInclude(s => s.Steps)
                .Include(c => c.Departments)
                    .ThenInclude(d => d.Courses)
                .ToListAsync();
        }
    
    public async Task<Campus> getCampus(int CampusId)
        {
            var result = await _adminDbContext.Campuses
                .Include(c => c.News.Where(n => n.IsVisible))
                .Include(c => c.Services)
                    .ThenInclude(s => s.Steps)
                .Include(c => c.Departments)
                    .ThenInclude(d => d.Courses)
                .FirstOrDefaultAsync(c => c.CampusId == CampusId);
            return result;


        }

        public async Task<List<Campus>> getCampusList()
        {
            return await _adminDbContext.Campuses
                .Include(c => c.News.Where(n => n.IsVisible))
                .Include(c => c.Services)
                    .ThenInclude(s => s.Steps)
                .Include(c => c.Departments)
                    .ThenInclude(d => d.Courses)
                .ToListAsync();
        }
    }
}
