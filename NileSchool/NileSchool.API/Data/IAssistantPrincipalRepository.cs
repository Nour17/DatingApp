using System.Threading.Tasks;
using NileSchool.API.Models;

namespace NileSchool.API.Data
{
    public interface IAssistantPrincipalRepository
    {
        Task<AssistantPrincipal> AddAp(AssistantPrincipal assistantPrincipal);
    }
}