using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstAngular.Models
{
    public class UsersRepository : IUserRepository
    {
        private readonly List<User> _usersDataList;

        public UsersRepository()
        {
            _usersDataList = new List<User>();
            GenerateUsersData();
        }

        public User GetUserById(int userId)
        {
            return _usersDataList
                .Where(u => u.Id == userId)
                .FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return _usersDataList;
        }

        private void GenerateUsersData()
        {
            for (int i = 0; i < 100; i++)
            {
                var user = new User()
                {
                    Id = i + 1,
                    Username = $"user{i}",
                    Password = $"user{i}",
                    FirstName = $"userName{i + 1}",
                    LastName = $"userLastName{i + 1}"
                };

                _usersDataList.Add(user);
            }
        }
    }
}
