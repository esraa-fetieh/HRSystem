using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.BLL.DTOs;
using HRSystem.DAL.Models;

namespace HRSystem.BLL.Repositories
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDTO>> GetDepartmentsAsync();
        Task<DepartmentDTO> GetDepartmentByIdAsync(int id);
        Task AddDepartmentAsync(DepartmentDTO departmentDto);
        Task UpdateDepartmentAsync(DepartmentDTO departmentDto, int id);
        Task DeleteDepartmentAsync(int id);
    }
}
