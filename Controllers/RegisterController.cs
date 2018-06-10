using Microsoft.AspNetCore.Mvc;
using myFirstAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstAngular.Controllers
{
    [Route("register")]
    public class RegisterController: Controller
    {
        IUserRepository _userRepository;

        public RegisterController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("")]
        public IActionResult PostRegister([FromBody] User newUser)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _userRepository.GetUsers(0, _userRepository.GetUsersCount())
                    .Where(user => user.FirstName == newUser.FirstName && user.LastName == newUser.LastName)
                    .FirstOrDefault();

                if (existingUser != null)
                {
                    return new ForbidResult();
                }
                else
                {
                    _userRepository.AddUser(newUser);
                    return Created("/user", newUser);
                }
            }
            else return BadRequest();
        }
    }
}
