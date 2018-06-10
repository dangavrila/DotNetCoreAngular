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

        public IEnumerable<User> GetUsers(int page, int rows)
        {
            return _usersDataList.Skip(page * rows).Take(rows);
        }

        public void AddUser(User user)
        {
            user.Id = _usersDataList.Max(u => u.Id) + 1;

            _usersDataList.Add(user);
        }

        public void UpdateUser(User userEdit)
        {
            var existingUser = _usersDataList.ElementAt(userEdit.Id - 1);
            if(existingUser != null)
            {
                existingUser.FirstName = userEdit.FirstName;
                existingUser.LastName = userEdit.LastName;
            }
        }

        public int GetUsersCount()
        {
            return _usersDataList.Count;
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
