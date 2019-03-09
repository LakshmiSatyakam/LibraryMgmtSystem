using LibraryMgmtSystem.Models;
using LibraryMgmtSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LibraryMgmtSystem.UnitTests")]

namespace LibraryMgmtSystem.Services
{
    /// <summary>
    /// Books borrow service class
    /// </summary>
    internal class BooksAssignService : IBooksAssignService
    {
        #region Private fields

        /// <summary>
        /// BooksRepository instance
        /// </summary>
        private IBooksRepository<Book> _booksRepository;

        /// <summary>
        /// AssignDetailsRepository instance
        /// </summary>
        private IAssignDetailsRepository<AssignDetails> _borrowDetailsRepository;

        #endregion

        #region Construction

        public BooksAssignService(IBooksRepository<Book> booksRepository, IAssignDetailsRepository<AssignDetails> borrowDetailsRepository)
        {
            _booksRepository = booksRepository;
            _borrowDetailsRepository = borrowDetailsRepository;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Checks whether a book can be borrowed or not
        /// </summary>
        /// <param name="bookId">book Id</param>
        /// <returns>Returns true if book can be borrowed, else false</returns>
        public bool CanAssignBook(int bookId)
        {
            // Check if any one has already borrowed the book
            var borrowedBook = _borrowDetailsRepository.Find(bookId);
            if (borrowedBook == null)
            {
                // Check if the book is available in library
                var validBook = _booksRepository.Find(bookId);
                if (validBook != null)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Assigns a book
        /// </summary>
        /// <param name="studentId">student Id</param>
        /// <param name="bookId">book Id</param>
        /// <returns>Returns true if borrowing was successful, else false</returns>
        public bool AssignBook(int studentId, int bookId)
        {
            var borrowedBook = _booksRepository.Find(bookId);
            if (borrowedBook == null)
            {
                return false;
            }

            IList<AssignDetails> borrorDetails = _borrowDetailsRepository.GetAll() as IList<AssignDetails>;
            borrorDetails.Add(new AssignDetails()
            {
                Id = borrorDetails.Count + 1,
                BookId = bookId,
                StudentId = studentId,
                DueDate = DateTime.Today.AddDays(AssignDetailsRepository.NoOfDaysBookToBeAssigned)
            });

            return true;
        }
    }

    #endregion
}