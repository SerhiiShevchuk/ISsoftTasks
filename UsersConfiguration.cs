using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_NET02_2
{
    class UsersConfiguration
    {
        public List<User> Users { get; set; }

        public void GetUsers(IRepository repo)
        {
            Users = repo.LoadUsers();
        }
        public void SaveUsers(IRepository repo)
        {
            repo.SaveUsers(Users);
        }
        public void PrintIncorrectUsers()
        {
            var incorrectUsers = Users.Where(u => !u.IsCorrect());
            foreach (var user in incorrectUsers)
            {
                Console.WriteLine(user.ToString() + "\n");
            }
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            if (Users != null)
            {
                foreach (var user in Users)
                {
                    str.Append(user?.ToString() + "\n");
                }
            }

            return str.ToString();
        }
    }
}
