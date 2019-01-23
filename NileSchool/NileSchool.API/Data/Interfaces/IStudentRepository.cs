using System.Collections.Generic;
using System.Threading.Tasks;
using NileSchool.API.Models;

namespace NileSchool.API.Data.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> CreateStudent(Student newStudent);

        Student GetStudent(int id);

        Task<IEnumerable<Student>> GetStudentsInClass(int classId);

        Task<IEnumerable<Student>> GetStudentsInGrade(int gradeId);

        int GetNumberOfStudentsInClass(int classId);

        Student AddStudentToClass(Student student, int classId);
    }
}