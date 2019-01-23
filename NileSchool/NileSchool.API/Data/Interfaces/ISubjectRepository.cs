using System.Collections.Generic;
using System.Threading.Tasks;
using NileSchool.API.Models;

namespace NileSchool.API.Data.Interfaces
{
    public interface ISubjectRepository
    {
        Task<Subject> CreateSubject(Subject subject);

         Task<Subject> GetSubject(int id);

         Task<IEnumerable<Subject>> GetSubjects();

         Task<bool> SubjectExist(string name);
    }
}