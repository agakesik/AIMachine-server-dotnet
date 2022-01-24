using AIMachineAPI.Models;

namespace AIMachineAPI.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
        Task Add(User user);
    }
}