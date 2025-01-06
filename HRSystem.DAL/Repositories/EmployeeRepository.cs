using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.DAL.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly HRSystemContext _db;
        public EmployeeRepository(HRSystemContext db)
        {
            _db = db;
        }
        public async Task<List<Employee>> GetEmployeesAsync()=>await _db.Employees.ToListAsync();
      
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var e = await _db.Employees.FindAsync(id);
            if (e == null) {
                return null;
            }
            return e;
            
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
           await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateEmployeeAsync(Employee employee)
        {
             _db.Employees.Update(employee);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var e =await _db.Employees.FindAsync(id);
            if (e != null)
            {
                _db.Employees.Remove(e);
                await _db.SaveChangesAsync();
            }

        }

       

      
    }
}
