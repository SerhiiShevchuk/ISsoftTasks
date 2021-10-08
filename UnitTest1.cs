using System;
using Xunit;
using Task_NET02_1.Entity;
using System.Linq;
using System.Collections.Generic;

namespace Task_NET02_1_Test
{
    public class UnitTest1
    {
        public string ISBN { get; } = "333-3-33-333333-3";

        [Theory]
        [InlineData("1234782333")]
        [InlineData("MMMM123456789")]
        [InlineData("1234567891234567")]
        [InlineData("123-4-56-478233-")]
        [InlineData("123-4-56478233-3")]
        [InlineData("123-4-56-11MMM1-4")]
        [InlineData("123-4-56478233-35445")]
        public void When_InvalidBookISBN_Expect_Exception(string value)
        {
            Assert.Throws<Exception>(() => new Book("adsf", value));
        }
        
        [Theory]
        //[InlineData(new string('c', 1000)]
        [InlineData(null)]
        public void When_BookTitleLonger1000_Expect_Exception(string value)
        {
            Assert.Throws<Exception>(() => new Book(title: null));
            Assert.Throws<Exception>(() => new Book(title: new string('c',1001)));
        }

        [Fact]
        public void When_BookPublicationDataIsNull_Expect_Null()
        {
            Book book = new Book(title: "title");
            Assert.Null(book.PublicationData);
        }

        [Fact]
        public void When_BooksAuthorsIsNull_Expect_Null()
        {
            Book book = new Book(title: "title");
            var authors = book.Authors;
            Assert.Null(authors);
        }

        [Fact]
        public void When_FirstAndLastNameIsNull_Expect_Exception()
        {
            Assert.Throws<Exception>(() => new Author(firstName: null, lastName: null));
        }

        [Fact]
        public void When_FirstAndLastNameLonger200_Expect_Exception()
        {
            Assert.Throws<Exception>(() 
                => new Author(firstName: new string('c', 201), new string('c', 201)));
        }

        [Theory]
        [InlineData("1234567891234")]
        [InlineData("222-2-22-222222-2")]
        public void When_CatalogIndexISBN_Expect_BookWithThisISBN(string value)
        {
            Book[] books = new Book[2] {
                new Book("t1", value),
                new Book("t2", "333-3-33-333333-3")
            };
            
            Catalog catalog = new Catalog(books);
            
            Assert.Equal(catalog[value].ISBN, value);
        }

        [Theory]
        [InlineData("2222222222222")]
        [InlineData("222-2-22-222222-2")]
        public void When_BookISBNTheSeems_Expect_isEquels(string value)
        {
            Book book1 = new Book("t1", value);
            Book book2 = new Book("t2", "222-2-22-222222-2");

            Assert.True(book1.Equals(book2));
        }

        [Theory]
        [InlineData("t1")]
        [InlineData("t8")]
        public void When_ForeachCatalog_Expext_SortBooksByTitle(string value)
        {
            Book[] books = new Book[4] {
                new Book(value, ISBN),
                new Book("t2", ISBN),
                new Book("t6", ISBN),
                new Book("t4", ISBN)
            };
            var sortedTitles = books.Select(b => b).Select(b => b.Title).OrderBy(b => b).ToList();

            Catalog catalog = new Catalog(books);
            List<string> sortedInCatalog = new();
            foreach (Book item in catalog)
            {
                sortedInCatalog.Add(item.Title);
            }

            Assert.Equal(sortedInCatalog, sortedTitles);
        }

        [Theory]
        [InlineData("firstname", "lastname")]
        [InlineData("FIRSTNAME", "LASTNAME")]
        public void GetBooksByAuthorName_BookThisAuthor_FirstAndLastNameInAnyRegister(string firstName, string lastName)
        {
            Author authorA = new("firstname", "lastname");
            Author authorB = new("name", "name");
            Book[] books = new Book[] {
                new Book("t1", ISBN, authors: new List<Author>(){ authorA, authorB }),
                new Book("t2", ISBN, authors: new List<Author>(){ authorA}),
                new Book("t3", ISBN, authors: new List<Author>(){ authorB })
            };
            Catalog catalog = new Catalog(books);

            var authorBooks = catalog.GetBooksByAuthorName(firstName, lastName);

            Assert.Equal(authorBooks, new Book[2] { books[0], books[1] });
        }

        [Fact]
        public void GetSortedBooksByData_BooksCollection()
        {
            Book[] books = new Book[4] {
                new Book("t3", ISBN, new DateTime(3)),
                new Book("t4", ISBN, new DateTime(4)),
                new Book("t2", ISBN, new DateTime(2)),
                new Book("t1", ISBN, new DateTime(1))
            };
            var sortedBooks = books.OrderByDescending(b => b.PublicationData).ToList();

            Catalog catalog = new Catalog(books);
            Book[] sortedbooksCatalog = catalog.GetSortedBooksByData();

            Assert.Equal(sortedbooksCatalog, sortedBooks);
        }

        [Fact]
        public void GetAuthorsAndCountBooks_CortegeAuthorAndCountBooks()
        {
            Author authorA = new("firstname", "lastname");
            Author authorB = new("name", "name");
            Book[] books = new Book[] {
                new Book("t1", ISBN, authors: new List<Author>(){ authorA, authorB }),
                new Book("t2", ISBN, authors: new List<Author>(){ authorA}),
                new Book("t3", ISBN, authors: new List<Author>(){ authorB })
            };

            Catalog catalog = new Catalog(books);
            var c = catalog.GetAuthorsAndCountBooks();

            Assert.Equal(c, new (Author, int)[2] { (authorA, 2), (authorB, 2) });
        }
    }
}
