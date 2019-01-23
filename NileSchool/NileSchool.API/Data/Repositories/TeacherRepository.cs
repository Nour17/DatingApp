using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NileSchool.API.Data.Interfaces;
using NileSchool.API.Models;

namespace NileSchool.API.Data.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DataContext _context;

        public TeacherRepository(DataContext context)
        {
            _context = context;
        }

        public Teacher AddTeacherToDepartment(Teacher teacherToUpdate, int departmentId)
        {
            teacherToUpdate.DepartmentId = departmentId;
            _context.Teachers.Update(teacherToUpdate);
            _context.SaveChanges();

            return teacherToUpdate;
        }

        public async Task<Teacher> CreateTeacher(Teacher newTeacher)
        {
            await _context.AddAsync(newTeacher);
            await _context.SaveChangesAsync();

            return newTeacher;
        }

        public Teacher GetTeacherToDisplay(int id)
        {
            var Teacher = _context.Teachers.Include(user => user.User).Include(department => department.Department).FirstOrDefault(x => x.Id == id);

            return Teacher;
        }

        public Teacher GetTeacherToUpdate(int id)
        {
            var Teacher = _context.Teachers.FirstOrDefault(x => x.Id == id);

            return Teacher;
        }

        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            var Teachers = await _context.Teachers.Include(user => user.User).Include(department => department.Department).ToListAsync();

            return Teachers;
        }

        public async Task<bool> TeacherExist(int id)
        {
            if(await _context.Teachers.AnyAsync(x => x.Id == id)){
                return true;
            } 

            return false;
        }
    }
}