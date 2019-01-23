using System.Threading.Tasks;
using NileSchool.API.Data.Interfaces;
using NileSchool.API.Models;

namespace NileSchool.API.Data.Repositories
{
    public class AssistantPrincipalRepository : IAssistantPrincipalRepository
    {
        private readonly DataContext _context;

        public AssistantPrincipalRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<AssistantPrincipal> AddAp(AssistantPrincipal assistantPrincipal)
        {            
            await _context.AddAsync(assistantPrincipal);
            await _context.SaveChangesAsync();

            return assistantPrincipal;
        }
    }
}