using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_NET02_1.Entity
{
    public class Catalog
    {
        public Catalog(Book[] books)
        {
            Books = books;
        }
        public Book this[string isbn]
        {
            get
            {
                if (!Books.Select(b => b.ISBN).Any(t => t == isbn))
                {
                    throw new IndexOutOfRangeException();
                }

                return Books.First(b => b.ISBN == isbn);
            }
            set
            {
                if (!Books.Select(b => b.ISBN).Any(t => t == isbn))
                {
                    throw new IndexOutOfRangeException();
                }

                Book book =  Books.First(b => b.ISBN == isbn);
                book = value;
            }
        }
        public IEnumerator GetEnumerator()
        {
            Array.Sort(Books);

            for (int i = 0; i < Books.Length; i++)
            {
                yield return Books[i];
            }
        }
        public IEnumerable<Book> GetBooksByAuthorName(string firstName, string lastName)
        {
            return Books.Where(b => b.Authors != null)
                        .Where(b => b.Authors
                        .Any(a  => a.FirstName.ToLower() == firstName.ToLower() 
                         && a.LastName.ToLower() == lastName.ToLower()));
        }
        public Book[] GetSortedBooksByData()
        {
            return Books.Where(b => b.PublicationData != null).OrderByDescending(b => b.PublicationData).ToArray();
        }
        public IEnumerable<(Author, int)> GetAuthorsAndCountBooks()
        {
            return Books.SelectMany(b => b.Authors, (b, a) => (b, a))
                        .GroupBy(c => c.a)
                        .Select(g => (g.Key, g.Count()));
        }

        public Book[] Books { get; set; }
    }
}
