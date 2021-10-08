using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task_NET02_1.Entity
{
    public class Book : IComparable
    {
        public Book( string title, string isbn = null, DateTime? publicationData = null, List<Author> authors = null )
        {
            string pattern = @"(^[0-9]{3}-[0-9]{1}-[0-9]{2}-[0-9]{6}-[0-9]{1}$)|(^[0-9]{13}$)";
            
            if (title == null || title.Length > 1000) 
            {
                throw new Exception();
            }
            if (isbn != null)
            {
                isbn = isbn.Trim();
                if (!Regex.IsMatch(isbn, pattern))
                {
                    throw new Exception();
                }
            }
            
            Title = title;
            ISBN = isbn;
            Authors = authors;
            PublicationData = publicationData?? null;
        }
        public override bool Equals(object obj)
        {
            if (obj is Book book)
            {
                if (ISBN.Replace("-", string.Empty) == book.ISBN.Replace("-", string.Empty))
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

        public string ISBN { get; set; }
        public string Title { get; set; }
        public DateTime? PublicationData { get; set; }
        public List<Author> Authors { get; set; }
    }
}
