using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_NET02_1.Entity
{
    public class Author
    {
        public Author(string firstName, string lastName)
        {
            if (firstName == null || lastName == null
                || firstName.Length > 200 || lastName.Length > 200) 
            {
                throw new Exception();
            }
            
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
