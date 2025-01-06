using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.DAL;
using HRSystem.DAL.Models;
using HRSystem.DAL.Repositories;
using HRSystem.BLL.DTOs;


namespace HRSystem.BLL.Services
{
   public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository )      
        {
            _employeeRepository=employeeRepository;
        }
        public async Task<List<EmployeeDTO>> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetEmployeesAsync();
            //if (employees != null) { 
            //    EmployeeDTO employeeDto = new()
            //    {
            //        EmployeeId = employees.EmployeeId,
            //         FirstName = employees.FirstName,
            //         LastName = employees.LastName,
            //         Email = employees.Email,
            //         DateOfBirth = employees.DateOfBirth,
            //         Position = employees.Position,
            //         DateHired = employees.DateHired

            //    };
            //return employeeDto;
            //}
            return employees.Select(e => new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                DateOfBirth = e.DateOfBirth,
                Position = e.Position,
                DateHired = e.DateHired



            }).ToList();

        }
            
        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {

            var employee= await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null) return null;
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Position = employee.Position,
                DateOfBirth= employee.DateOfBirth,
                DateHired= employee.DateHired

            
            };
        }
        public async Task AddEmployeeAsync(EmployeeDTO employeeDto)
        {
            var employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Position = employeeDto.Position,
                DateOfBirth = employeeDto.DateOfBirth,
                DateHired = employeeDto.DateHired
            };
            await _employeeRepository.AddEmployeeAsync(employee);
        } 
        public async Task UpdateEmployeeAsync(EmployeeDTO employeeDto, int id )
        {
            var employee= await _employeeRepository.GetEmployeeByIdAsync (id);
            if (employee == null) return;


            employee.FirstName = employeeDto.FirstName;
            employee.LastName = employeeDto.LastName;
            employee.Email = employeeDto.Email;
            employee.Position = employeeDto.Position;
            employee.DateOfBirth = employeeDto.DateOfBirth;
            employee.DateHired = employeeDto.DateHired;  
            
            await _employeeRepository.UpdateEmployeeAsync(employee);
            

        } 
        public async Task  DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null) return;
             await _employeeRepository.DeleteEmployeeAsync(id);

        }






    }
}
