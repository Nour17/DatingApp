using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NileSchool.API.Data.Interfaces;
using NileSchool.API.Models;

namespace NileSchool.API.Data.Repositories
{
    public class SubjectRebository : ISubjectRepository
    {
        private readonly DataContext _context;
        public SubjectRebository(DataContext context)
        {
            _context = context;
        }

        public async Task<Subject> CreateSubject(Subject subject)
        {
            await _context.AddAsync(subject);
            await _context.SaveChangesAsync();

            return subject;
        }

        public async Task<Subject> GetSubject(int id)
        {
            var subject = await _context.Subjects.Include(D => D.Department).FirstOrDefaultAsync(x => x.Id == id);

            return subject;
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            var subjects = await _context.Subjects.Include(D => D.Department).ToListAsync();

            return subjects;
        }

        public async Task<bool> SubjectExist(string name)
        {
            if(await _context.Subjects.AnyAsync(x => x.Name == name)){
                return true;
            }

            return false;
        }
    }
}