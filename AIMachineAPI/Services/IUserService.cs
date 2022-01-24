using AIMachineAPI.Models;

namespace AIMachineAPI.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        void Add(User user);
    }
}