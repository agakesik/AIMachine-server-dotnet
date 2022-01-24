using AIMachineAPI.Models;

namespace AIMachineAPI.Services
{
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
            {
                new User { Id = 1, Username = "test", Password = "test"}
            };

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.First());
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await Task.Run(() => _users);
            return users;
        }

        public async Task Add(User user)
        {
            await Task.Run(() => _users.Add(user));
        }
    }
}
