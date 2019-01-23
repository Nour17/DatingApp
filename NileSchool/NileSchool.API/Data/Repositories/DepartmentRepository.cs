using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NileSchool.API.Data.Interfaces;
using NileSchool.API.Models;

namespace NileSchool.API.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;

        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> DepartmentExist(string departmentName)
        {
            if(await _context.Departments.AnyAsync(x => x.Name == departmentName)){
                return true;
            }

            return false;
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            var department = await _context.Departments.Include(user => user.User).FirstOrDefaultAsync(x => x.Id == departmentId);

            return department;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var departments = await _context.Departments.Include(user => user.User).ToListAsync();

            return departments;
        }
    }
}