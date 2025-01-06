using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.DAL
{
    public class HRSystemContext:DbContext
    {
        public HRSystemContext(DbContextOptions<HRSystemContext> options):base(options) { }
      

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; } 
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
      
        
    }
}
