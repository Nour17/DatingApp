using System.Threading.Tasks;
using NileSchool.API.Models;

namespace NileSchool.API.Data.Interfaces
{
    public interface IAssistantPrincipalRepository
    {
        Task<AssistantPrincipal> AddAp(AssistantPrincipal assistantPrincipal);
    }
}