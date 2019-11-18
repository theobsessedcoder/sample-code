using System;
using Xunit;
using Users.InternalLibrary.Repositories;
using Users.InternalLibrary.Exceptions;

namespace Users.Tests.InternalLibrary.Repositories
{
    public class UserRepositoryTests
    {
        private readonly InMemoryUserRepository _userRepository;

        public UserRepositoryTests()
        {
            _userRepository = new InMemoryUserRepository();
        }

        [Fact]
        public void ConfirmThatGettingNonExistentUserThrows()
        {
            Assert.Throws<UserNotFoundException>(() => _userRepository.Get(Guid.NewGuid()));
        }

        //TODO: more tests...
    }
}
