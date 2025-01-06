using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.BLL.DTOs;
using HRSystem.DAL.Models;

namespace HRSystem.DAL.Repositories
{
   public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetEmployeesAsync();
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(EmployeeDTO employeeDto);
        Task UpdateEmployeeAsync(EmployeeDTO employeeDto, int id);
        Task DeleteEmployeeAsync(int id);
    }
}
