using System.Collections.Generic;
using System.Threading.Tasks;
using NileSchool.API.Models;

namespace NileSchool.API.Data.Interfaces
{
    public interface ITeacherRepository
    {
        Task<Teacher> CreateTeacher(Teacher newTeacher);

        Task<IEnumerable<Teacher>> GetTeachers();

        Teacher GetTeacherToUpdate(int id);

        Teacher GetTeacherToDisplay(int id);

        Task<bool> TeacherExist(int id);

        Teacher AddTeacherToDepartment(Teacher teacher, int departmentId);
    }
}