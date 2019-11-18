using System;
using Microsoft.AspNetCore.Mvc;
using Users.Client.Dtos;
using Users.InternalLibrary.Repositories;
using Users.InternalLibrary.Models;

namespace Users.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public UserDto GetUserById(Guid id)
        {
            var user = _userRepository.Get(id);

            //Convert the domain model to the application DTO:
            return new UserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        [HttpDelete("{id}")]
        public void DeleteUser(Guid id)
        {
            _userRepository.Delete(id);
        }

        [HttpPut()]
        public void AddOrUpdateUser(UserDto userDto)
        {
            //Convert the application dto to the domain model and save:
            var user = new User(userDto.Id, userDto.FirstName, userDto.LastName);
            _userRepository.AddOrUpdate(user);
        }
    }
}
