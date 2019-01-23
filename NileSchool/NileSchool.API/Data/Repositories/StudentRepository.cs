using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NileSchool.API.Data.Interfaces;
using NileSchool.API.Models;

namespace NileSchool.API.Data.Repositories
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

        public Student GetStudent(int id)
        {
            var student =  _context.Students.FirstOrDefault(x => x.Id == id);

            return student;
        }

        public async Task<IEnumerable<Student>> GetStudentsInClass(int classId)
        {
            var students = await _context.Students.ToListAsync();

            var filteredStudents = students.Where(x => x.ClassId == classId);

            return filteredStudents;
        }

        public int GetNumberOfStudentsInClass(int classId)
        {
            var studentsInClass = _context.Students.ToList();

            var filteredStudents = studentsInClass.Where(x => x.ClassId == classId);
            int studentNumber = filteredStudents.Count();

            return studentNumber;
        }

        public async Task<IEnumerable<Student>> GetStudentsInGrade(int gradeId)
        {
            var students = await _context.Students.ToListAsync();

            var filteredStudents = students.Where(x => x.Class.GradeId == gradeId);

            return filteredStudents;
        }

        public Student AddStudentToClass(Student student, int classId)
        {
            student.ClassId = classId;
            _context.Students.Update(student);
            _context.SaveChanges();

            return student;
        }
    }
}