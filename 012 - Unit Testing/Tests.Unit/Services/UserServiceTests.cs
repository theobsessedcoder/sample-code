using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moq;
using UserServiceExample.Exceptions;
using UserServiceExample.Models;
using UserServiceExample.Repositories;
using UserServiceExample.Services;
using Xunit;

namespace Tests.Unit.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _userRepository = new Mock<IUserRepository>();
            _userService = new UserService(_userRepository.Object);
        }

        [Fact]
        public async Task ConfirmThatMissingUserLastNameYieldsException()
        {
            var userId = Guid.NewGuid();
            var userWithMissingLastName = new User()
            {
                Id = userId,
                FirstName = "James"
            };

            //Setup the mocked repository to return a user with a missing last name when requested:
            _userRepository.Setup(r => r.GetAsync(userId)).ReturnsAsync(userWithMissingLastName);

            //Confirm that the service throws a NamelessUserException when it it 
            //encounters a user with a missing last name:
            await Assert.ThrowsAsync<NamelessUserException>(() => _userService.GetUserNameAsync(userId));
        }
    }
}
