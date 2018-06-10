using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myFirstAngular.Models;

namespace myFirstAngular.Controllers
{
    [Route("user")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("")]
        public IActionResult Get([FromQuery] int page = 0, int rows = 10)
        {
            var users = _userRepository.GetUsers(page, rows);
            return Ok(new UsersViewModel() {
                Data = users,
                Total = _userRepository.GetUsersCount()
            });
        }

        [HttpGet("/{id}")]
        public IActionResult Get(int userId)
        {
            var result = _userRepository.GetUserById(userId);
            return Ok(result);
        }

        [HttpPost("")]
        public IActionResult Post([FromBody] User newUser)
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

        [HttpPut("")]
        [Route("/user/{id:int}")]
        public IActionResult Put([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                int userId = 0;
                int.TryParse((string)RouteData.Values["id"], out userId);
                var existingUser = _userRepository.GetUserById(userId);
                if (existingUser != null)
                {
                    user.Id = userId;
                    _userRepository.UpdateUser(user);
                    return Created($"/user/{userId}", user);
                }
                else return NotFound(user);
            }
            else return BadRequest();
        }

    }
}