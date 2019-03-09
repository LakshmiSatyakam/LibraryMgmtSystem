using LibraryMgmtSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LibraryMgmtSystem.UnitTests")]

namespace LibraryMgmtSystem.Repositories
{
    /// <summary>
    /// BooksRepository class
    /// </summary>
    internal class BooksRepository : IBooksRepository<Book>
    {
        #region Private fields

        /// <summary>
        /// List of books
        /// </summary>
        private IList<Book> _books = new List<Book>() {
            new Book() { Id = 1, Name = "Year 3 NAPLAN Literacy tests" },
            new Book() { Id = 2, Name = "The Girl who saved the king of sweden" },
            new Book() { Id = 3, Name = "Hundred years of solitude" },
            new Book() { Id = 4, Name = "Sophie's world" },
            new Book() { Id = 5, Name = "The Phoenix project: A novel about IT, DevOps & Helping your business win" },
            new Book() { Id = 6, Name = "Matilda" },
            new Book() { Id = 7, Name = "Tom Gates Epic" },
            new Book() { Id = 8, Name = "Dairy of Anne Frank" },
        };

        #endregion

        #region Implementation of IBooksRepostiory

        /// <summary>
        /// Returns list of books
        /// </summary>
        /// <returns>List of books</returns>
        public IEnumerable<Book> GetAll()
        {
            return _books;
        }

        /// <summary>
        /// Finds a book in the library
        /// </summary>
        /// <param name="id">Book Id to be found</param>
        /// <returns>Returns book object if found, else returns null</returns>
        public Book Find(int id)
        {
            try
            {
                if (_books.Where(x => x.Id == id).Count() == 0)
                {
                    return null;
                }

                return _books.Where(x => x.Id == id).First();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        #endregion
    }
}