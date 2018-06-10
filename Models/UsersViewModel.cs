using myFirstAngular.Models;
using System.Collections.Generic;

namespace myFirstAngular.Controllers
{
    public class UsersViewModel
    {
        public IEnumerable<User> Data { get; set; }
        public int Total { get; set; }
    }
}
