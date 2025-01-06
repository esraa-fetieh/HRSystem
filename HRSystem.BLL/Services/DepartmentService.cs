using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.BLL.DTOs;
using HRSystem.BLL.Repositories;
using HRSystem.DAL;
using HRSystem.DAL.Models;
using HRSystem.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.BLL.Services
{
    public class DepartmentService :IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<List<DepartmentDTO>> GetDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetDepartmentsAsync();
            
            
            return departments.Select(d => new DepartmentDTO
            {
                DepartmentId = d.DepartmentId,
                DepartmentName = d.DepartmentName,
                Description = d.Description
            }).ToList();

        }

        public async Task<DepartmentDTO> GetDepartmentByIdAsync(int id)
        {

            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (department == null) return null;
            return new DepartmentDTO
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                Description=department.Description,
            };
        }
        public async Task AddDepartmentAsync(DepartmentDTO departmentDto)
        {
            var department = new Department 
            {
                
                DepartmentName = departmentDto.DepartmentName, 
                Description = departmentDto.Description,
            };
            await _departmentRepository.AddDepartmentAsync(department);
        }
        public async Task UpdateDepartmentAsync(DepartmentDTO departmentDto, int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (department == null) return;


            department.DepartmentName = departmentDto.DepartmentName;
            await _departmentRepository.UpdateDepartmentAsync(department);


        }
        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (department == null) return;
            await _departmentRepository.DeleteDepartmentAsync(id);

        }
    }
}
