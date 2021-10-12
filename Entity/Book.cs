using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task_NET02_1.Entity
{
    public class Book : IComparable
    {
        public Book( string title, string isbn = null, DateTime? publicationData = null, List<Author> authors = null )
        {
            Title = title;
            ISBN = isbn;
            Authors = authors;
            PublicationData = publicationData?? null;
        }
        public override bool Equals(object obj)
        {
            if (obj is Book book)
            {
                if (this.ISBN == book.ISBN)
                {
                    return true;
                }
            }

            return false;
         }
        public int CompareTo(object obj)
        {
            if (obj is Book book)
            {
                return this.Title.CompareTo(book.Title);
            }
            else
            {
                throw new Exception("Can't compare two objects");
            }
        }

        private string _pattern = @"(^[0-9]{3}-[0-9]{1}-[0-9]{2}-[0-9]{6}-[0-9]{1}$)|(^[0-9]{13}$)";
        private string _isbn;
        public string ISBN
        {
            get
            {
                return _isbn;
            }
            set
            {
                if (value != null)
                {
                    value = value.Trim();
                    if (!Regex.IsMatch(value, _pattern))
                    {
                        throw new Exception("Invalid format ISBN");
                    }
                }

                _isbn = value?.Replace("-", string.Empty) ?? null;
            }
        }
        private string _title;
        public string Title 
        {
            get
            {
                return _title;
            }
            set
            {
                const int SIZE = 1000;
                if (value == null || value.Length > SIZE)
                {
                    throw new Exception($"Title can't be empty or longer {SIZE}");
                }
              
                _title = value;
            }
        }
        public DateTime? PublicationData { get; set; }
        public List<Author> Authors { get; set; }
    }
}
