using System.Threading.Tasks;
using NileSchool.API.Models;

namespace NileSchool.API.Data
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