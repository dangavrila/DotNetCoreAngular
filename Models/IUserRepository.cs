using System.Collections.Generic;

namespace myFirstAngular.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers(int page, int rows);

        User GetUserById(int userId);

        void AddUser(User user);

        void UpdateUser(User userEdit);

        int GetUsersCount();
    }
}
