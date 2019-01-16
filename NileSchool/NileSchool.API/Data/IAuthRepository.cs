using System.Collections.Generic;
using System.Threading.Tasks;
using NileSchool.API.Models;

namespace NileSchool.API.Data
{
    public interface IAuthRepository
    {
        Task<User> MakeUser(User user, string password);

        Task<User> LoginAsync(string username, string password);

        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(int id);

        Task<bool> UserExists(string username);      
    }
}