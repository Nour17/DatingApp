using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NileSchool.API.Models;

namespace NileSchool.API.Data
{
    public class GradeRepository : IGradeRepository
    {
        private readonly DataContext _context;
        public GradeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Grade> CreateGrade(Grade grade)
        {
            grade.Created = DateTime.Now;
            grade.LastUpdated = DateTime.Now;

            await _context.AddAsync(grade);
            await _context.SaveChangesAsync();

            return grade;
        }

        public async Task<Grade> GetGrade(int id)
        {
            var grade = await _context.Grades.Include(ap => ap.AssistantPrincipal).Include(ac => ac.AcademicYear).FirstOrDefaultAsync(x => x.Id == id);

            return grade;
        }

        public async Task<IEnumerable<Grade>> GetGrades()
        {
            var grades = await _context.Grades.Include(ap => ap.AssistantPrincipal).Include(ac => ac.AcademicYear).ToListAsync();

            return grades;
        }

        public async Task<bool> GradeExist(string name)
        {
            if(await _context.Grades.AnyAsync(x => x.Name == name)){
                return true;
            }

            return false;
        }
    }
}