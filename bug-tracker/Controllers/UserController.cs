using bug_tracker.Classes;
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
        public RequestResponse Update([FromBody] User user){
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var updated = _userRepository.UpdateWithoutNull(user);

            return new RequestResponse { Message = "Dados atualizados com sucesso", Data = updated };
        }
    }
}