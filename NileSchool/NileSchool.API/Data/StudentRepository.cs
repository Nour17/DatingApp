using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NileSchool.API.Models;

namespace NileSchool.API.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateStudent(Student newStudent)
        {
            await _context.AddAsync(newStudent);
            await _context.SaveChangesAsync();

            return newStudent;
        }

        public async Task<Student> GetStudent(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            return student;
        }

        public async Task<IEnumerable<Student>> GetStudentsInClass(int classId)
        {
            var students = await _context.Students.ToListAsync();

            var filteredStudents = students.Where(x => x.ClassId == classId);

            return filteredStudents;
        }

        public async Task<IEnumerable<Student>> GetStudentsInGrade(int gradeId)
        {
            var students = await _context.Students.ToListAsync();

            var filteredStudents = students.Where(x => x.Class.GradeId == gradeId);

            return filteredStudents;
        }
    }
}