using System.Collections.Generic;

namespace myFirstAngular.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int userId);
    }
}
