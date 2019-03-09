using LibraryMgmtSystem.Models;
using LibraryMgmtSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LibraryMgmtSystem.UnitTests")]

namespace LibraryMgmtSystem.Services
{
    /// <summary>
    /// BooksService class
    /// </summary>
    internal class BooksService : IBooksService
    {
        #region Private fields

        /// <summary>
        /// BooksRepository instance
        /// </summary>
        private IBooksRepository<Book> _booksRepository;

        /// <summary>
        /// Assign details repository instance
        /// </summary>
        private IAssignDetailsRepository<AssignDetails> _borrowDetailsRepository;

        #endregion

        #region Construction

        public BooksService(IBooksRepository<Book> booksRepository, IAssignDetailsRepository<AssignDetails> borrowDetailsRepository)
        {
            _booksRepository = booksRepository;
            _borrowDetailsRepository = borrowDetailsRepository;
        }

        #endregion

        #region Implementing IBooksService

        /// <summary>
        /// Retrieves list of all books
        /// </summary>
        /// <returns>List of books</returns>
        public IEnumerable<Book> GetAll()
        {
            return _booksRepository.GetAll();
        }

        /// <summary>
        /// Returns the list of overdue books
        /// </summary>
        /// <returns>List of overdue books</returns>
        public IEnumerable<Book> GetOverdueBooks()
        {
            try
            {
                var books = _booksRepository.GetAll();
                var overdue = _borrowDetailsRepository.GetAll().Where(x => x.DueDate < DateTime.Today);

                IEnumerable<Book> overdueBooks = (from book in books
                                                  join overdueBook in overdue
                                                  on book.Id equals overdueBook.BookId
                                                  select new Book() { Id = book.Id, Name = book.Name });

                return overdueBooks;
            }
            catch (NullReferenceException)
            {
                return new List<Book>();
            }
            catch (ArgumentNullException)
            {
                return new List<Book>();
            }
        }

        /// <summary>
        /// Checks whether the book is available in library
        /// </summary>
        /// <param name="bookId">book Id</param>
        /// <returns>True if book is available in the library, else false</returns>
        public bool IsValidBook(int bookId)
        {
            return (_booksRepository.Find(bookId) != null);
        }

        #endregion
    }
}