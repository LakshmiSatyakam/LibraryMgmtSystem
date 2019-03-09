using LibraryMgmtSystem.Models;
using LibraryMgmtSystem.Repositories;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LibraryMgmtSystem.UnitTests")]

namespace LibraryMgmtSystem.Services
{
    /// <summary>
    /// Books renew service class
    /// </summary>
    internal class BooksRenewService : IBooksRenewService
    {
        #region Private fields

        /// <summary>
        /// AssignDetailsRepository instance
        /// </summary>
        private IAssignDetailsRepository<AssignDetails> _borrowDetailsRepository;

        #endregion

        #region Construction

        public BooksRenewService(IAssignDetailsRepository<AssignDetails> borrowDetailsRepository)
        {
            _borrowDetailsRepository = borrowDetailsRepository;
        }

        #endregion

        #region Implmenting IBooksRenewService

        /// <summary>
        /// Checks whether a book can be renewed or not
        /// </summary>
        /// <param name="bookId">book Id</param>
        /// <returns>Returns true if book can be renewed, else false</returns>
        public bool CanRenewBook(int bookId)
        {
            var borrowedBook = _borrowDetailsRepository.Find(bookId);
            return borrowedBook != null;
        }

        /// <summary>
        /// Checks whether book is borrowed by the same student requesting for renewal
        /// </summary>        
        /// <param name="bookId">book Id</param>
        /// <param name="studentId">student Id</param>
        /// <returns>Returns true if book can be renewed, else false</returns>
        public bool IsValidRenewal(int bookId, int studentId)
        {
            return _borrowDetailsRepository.Find(bookId, studentId) != null;
        }

        /// <summary>
        /// Renews a book
        /// </summary>
        /// <param name="bookId">book Id</param>
        /// <param name="studentId">student Id</param>
        /// <returns>Returns true if book renewal was successfull, else false</returns>
        public bool RenewBook(int bookId, int studentId)
        {
            var borrowDetail = _borrowDetailsRepository.Find(bookId, studentId);
            if (borrowDetail != null)
            {
                borrowDetail.DueDate = DateTime.Today.AddDays(AssignDetailsRepository.NoOfDaysBookToBeAssigned);
                return true;
            }

            return false;
        }

        #endregion
    }
}