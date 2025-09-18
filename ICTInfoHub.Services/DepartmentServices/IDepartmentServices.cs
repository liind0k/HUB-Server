using ICTInfoHub.Model.Model.DTOs;
using ICTInfoHub.Model.Model.DTOs.CampusDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Services.DepartmentServices
{
    public interface IDepartmentServices
    {
        Task<List<DepartmentDTO>> GetDepartmentListAsync();
        Task<CampusDepartmentDTO> GetDepartmentByIdAsync(int CampusId, int DepartmentId);
        Task<bool> updateDepartmentPhone(UpdateDepartmentDTO updateDepartment);
        Task<bool> updateDepartmentLocation(UpdateDepartmentDTO updateDepartment);
        Task<bool> updateDepartmentEmail(UpdateDepartmentDTO updateDepartment);
    }
}
