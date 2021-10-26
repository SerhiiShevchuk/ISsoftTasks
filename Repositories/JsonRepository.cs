using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task_NET02_2.Repositories
{
    class JsonRepository : IRepository
    {
        public List<User> LoadUsers()
        {
            using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                return  JsonSerializer.DeserializeAsync<List<User>>(fs).Result;
            }
        }
        public async void SaveUsers(List<User> users)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<List<User>>(fs, users, options);
            }
        }

        private string _path = @"..\..\..\Config\User`sWindowsSettings.json";
    }
}
