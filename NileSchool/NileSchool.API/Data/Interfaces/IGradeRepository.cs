using System.Collections.Generic;
using System.Threading.Tasks;
using NileSchool.API.Models;

namespace NileSchool.API.Data.Interfaces
{
    public interface IGradeRepository
    {
         Task<Grade> CreateGrade(Grade grade);

         Task<Grade> GetGrade(int id);

         Task<IEnumerable<Grade>> GetGrades();

         Task<bool> GradeExist(string name);
    }
}