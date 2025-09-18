using ICTInfoHub.Model.Model;
using ICTInfoHub.Model.Model.DTOs;
using ICTInfoHub.Model.Model.DTOs.CampusDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Services.DepartmentServices
{
    internal class DepartmentServices : IDepartmentServices
    {
        AdminDbContext _context;

        public DepartmentServices(AdminDbContext context)
        {
            _context = context;
        }
        public async Task<CampusDepartmentDTO> GetDepartmentByIdAsync(int CampusId,int DepartmentId)
        {
            var department = _context.Set<CampusDepartment>().Select( d => new CampusDepartmentDTO()
            {

            }).SingleOrDefault();
            return department;
        }

        public Task<List<DepartmentDTO>> GetDepartmentListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> updateDepartmentEmail(UpdateDepartmentDTO updateDepartment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> updateDepartmentLocation(UpdateDepartmentDTO updateDepartment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> updateDepartmentPhone(UpdateDepartmentDTO updateDepartment)
        {
            throw new NotImplementedException();
        }
    }
}
