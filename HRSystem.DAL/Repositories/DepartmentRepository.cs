using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.DAL.Repositories
{
    public class DepartmentRepository: IDepartmentRepository
    {
        private readonly HRSystemContext _db;
        public DepartmentRepository(HRSystemContext db)
        {
            _db = db;
        }
        public async Task<List<Department>> GetDepartmentsAsync()=> await _db.Departments.ToListAsync();
      
        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var d = await _db.Departments.FindAsync(id);
            if (d == null) {
                return null;
            }
            return d;
            
        }

        public async Task AddDepartmentAsync(Department department)
        {
           await _db.Departments.AddAsync(department);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateDepartmentAsync(Department department )
        {
             _db.Departments.Update(department);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var d =await _db.Departments.FindAsync(id);
            if (d != null)
            {
                _db.Departments.Remove(d);
                await _db.SaveChangesAsync();
            }

        }

       

      
    }
}
