using AIMachineAPI.Models;

namespace AIMachineAPI.Services
{
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
            {
                new User { Id = 1, Username = "test", Password = "test"}
            };

        public User Authenticate(string username, string password)
        {
            var user = _users.First();
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public void Add(User user)
        {
            _users.Add(user);
        }
    }
}
