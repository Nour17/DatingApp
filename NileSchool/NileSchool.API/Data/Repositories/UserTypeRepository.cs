using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NileSchool.API.Data.Interfaces;

namespace NileSchool.API.Data.Repositories
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly DataContext _context;

        public UserTypeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> isAssistantPrincipal(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            return user.UserTypeId == 4; 
        }

        public async Task<bool> isExamOfficer(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            return user.UserTypeId == 3; 
        }

        public async Task<bool> isHeadOfCenter(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            return user.UserTypeId == 1; 
        }

        public async Task<bool> isHeadOfDepartment(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            return user.UserTypeId == 5; 
        }

        public async Task<bool> isHumanResources(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            return user.UserTypeId == 8; 
        }

        public async Task<bool> isSeniorAdmin(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            return user.UserTypeId == 2; 
        }

        public async Task<bool> isStudentAffairs(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            return user.UserTypeId == 7; 
        }

        public async Task<bool> isTeacher(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            return user.UserTypeId == 6; 
        }
    }
}