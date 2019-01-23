using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NileSchool.API.Data.Interfaces;
using NileSchool.API.Models;

namespace NileSchool.API.Data.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly DataContext _context;

        public ClassRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> ClassExist(string name, int gradeId)
        {
            if(await _context.Classes.AnyAsync(x => x.Name == name && x.GradeId == gradeId)){
                return true;
            }

            return false;
        }

        public async Task<Class> CreateClass(Class newClass)
        {
            await _context.AddAsync(newClass);
            await _context.SaveChangesAsync();

            return newClass;
        }

        public async Task<Class> GetClass(int id)
        {
            var fetchedClass = await _context.Classes.FirstOrDefaultAsync(x => x.Id == id);

            return fetchedClass;
        }

        public async Task<IEnumerable<Class>> GetClasses()
        {
            var fetchedClasses = await _context.Classes.ToListAsync();

            return fetchedClasses;
        }
    }
}