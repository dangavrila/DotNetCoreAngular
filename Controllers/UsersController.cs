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

        public UsersController()
        {
            _userRepository = new UsersRepository();
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var result = _userRepository.GetUsers();
            return Ok(result);
        }

        [HttpGet("/{id}")]
        public IActionResult Get(int userId)
        {
            var result = _userRepository.GetUserById(userId);
            return Ok(result);
        }
    }
}