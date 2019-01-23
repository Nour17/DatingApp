using System.Threading.Tasks;

namespace NileSchool.API.Data.Interfaces
{
    public interface IUserTypeRepository
    {
        Task<bool> isHeadOfCenter(int userId);

        Task<bool> isSeniorAdmin(int userId);

        Task<bool> isExamOfficer(int userId);

        Task<bool> isAssistantPrincipal(int userId);

        Task<bool> isHeadOfDepartment(int userId);

        Task<bool> isTeacher(int userId);

        Task<bool> isStudentAffairs(int userId);

        Task<bool> isHumanResources(int userId);

    }
}