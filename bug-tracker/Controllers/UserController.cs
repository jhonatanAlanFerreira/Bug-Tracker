using bug_tracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace bug_tracker.controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPut]
        public User Update([FromBody] User user){
            return _userRepository.Update(user);
        }
    }
}