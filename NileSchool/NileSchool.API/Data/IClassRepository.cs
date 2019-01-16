using System.Collections.Generic;
using System.Threading.Tasks;
using NileSchool.API.Models;

namespace NileSchool.API.Data
{
    public interface IClassRepository
    {
        Task<Class> CreateClass(Class newClass);

        Task<Class> GetClass(int id);

        Task<IEnumerable<Class>> GetClasses();

        Task<bool> ClassExist(string name, int gradeId);
    }
}