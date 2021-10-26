using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_NET02_2
{
    interface IRepository
    {
        public List<User> LoadUsers();
        public void SaveUsers(List<User> users);
    }
}
