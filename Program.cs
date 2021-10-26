using System;
using System.Collections.Generic;
using Task_NET02_2.Repositories;

namespace Task_NET02_2
{
    class Program
    {
        static void Main(string[] args)
        {
            UsersConfiguration configuration = new UsersConfiguration();

            User user1 = new User() //correct
            {
                Name = "user1",
                Windows = null
            };
            User user2 = new User() //correct
            {
                Name = "user2",
                Windows = new List<Window> { new Window { Height = 50, Width = 100, Left = 20, Title = "BobWindow", Top = 50 } }
            };
            User user3 = new User() //correct
            {
                Name = "user3",
                Windows = new List<Window> { new Window { Height = 50, Width = 100, Left = 20, Title = "main", Top = 50 } }
            };
            User user4 = new User()
            {
                Name = "user4",
                Windows = new List<Window> { new Window { Height = 50, Title = "main", Top = 50 } }
            };

            configuration.GetUsers(new XmlRepository());
            configuration.Users = new List<User> { user1, user2, user3, user4 };
            configuration.SaveUsers(new XmlRepository());
            Console.WriteLine(configuration.ToString());
            configuration.PrintIncorrectUsers();

            configuration.SaveUsers(new JsonRepository());
            configuration.GetUsers(new JsonRepository());

            Console.WriteLine(configuration.Users[0].Name);
        }
    }
}
