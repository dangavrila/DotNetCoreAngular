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
    }
}