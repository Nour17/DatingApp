using System.Collections.Generic;
using System.Threading.Tasks;
using NileSchool.API.Models;

namespace NileSchool.API.Data
{
    public interface IStudentRepository
    {
        Task<Student> CreateStudent(Student newStudent);

        Task<Student> GetStudent(int id);

        Task<IEnumerable<Student>> GetStudentsInClass(int classId);

        Task<IEnumerable<Student>> GetStudentsInGrade(int gradeId);
    }
}