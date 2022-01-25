using AIMachineAPI.Models;
using AIMachineAPI.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AIMachineAPI.Tests.ServicesTests
{
    public class UserServiceTest
    {
        [Fact]
        public async void Authenticate_ShouldReturnValidUser()
        {
            var expected = new User { Id = 1, Username = "test", Password = "test" };
            var userService = new UserService();

            var actual = await userService.Authenticate("test", "test");

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Username, actual.Username);
            Assert.Equal(expected.Password, actual.Password);

        }

        [Fact]
        public async void Authenticate_ShouldReturnNullWithCredentialsNotMatching()
        {
            UserService userService = new UserService();

            var wrongUsername = await userService.Authenticate("nietest", "test");
            var wrongPassword = await userService.Authenticate("test", "nietest");
            var wrongCredentials = await userService.Authenticate("nietest", "nietest");

            Assert.Null(wrongUsername);
            Assert.Null(wrongPassword);
            Assert.Null(wrongCredentials);
        }
    }
}
