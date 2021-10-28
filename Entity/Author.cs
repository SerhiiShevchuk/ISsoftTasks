using System;

namespace Task_NET02_1.Entity
{
    public class Author
    {
        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        private const int SIZE = 200;
        private string _firstName;
        public string FirstName 
        {
            get
            {
                return _firstName;
            }
            set 
            {
                if (value == null|| value.Length > SIZE)
                {
                    throw new ArgumentException($"First name can't be empty or longer {SIZE}");
                }
               
                _firstName = value;
            }
        }
        private string _lasttName;
        public string LastName
        {
            get
            {
                return _lasttName;
            }
            set
            {
                if (value == null || value.Length > SIZE)
                {
                    throw new ArgumentException($"Last name can't be empty or longer {SIZE}");
                }

                _lasttName = value;
            }
        }
    }
}
