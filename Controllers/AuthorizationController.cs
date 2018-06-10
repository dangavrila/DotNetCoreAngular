using Microsoft.AspNetCore.Mvc;
using myFirstAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstAngular.Controllers
{
    [Route("login")]
    public class AuthorizationController: Controller
    {
        IUserRepository _userRepository;

        public AuthorizationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("")]
        public IActionResult PostLogin([FromBody] Credentials credentials)
        {
            var result = _userRepository.GetUsers(0, _userRepository.GetUsersCount())
                .Where(u => u.Username == credentials.Username && u.Password == credentials.Password).FirstOrDefault();

            return Ok(result);
        }
    }
}
