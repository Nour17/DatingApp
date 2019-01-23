using System.Collections.Generic;
using System.Threading.Tasks;
using NileSchool.API.Models;

namespace NileSchool.API.Data.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department> CreateDepartment(Department department);

        // Task<Department> UpdateDepartment(Department department, int departmentId);

        Task<IEnumerable<Department>> GetDepartments();

        Task<Department> GetDepartment(int departmentId);

        Task<bool> DepartmentExist(string departmentName); 
    }
}