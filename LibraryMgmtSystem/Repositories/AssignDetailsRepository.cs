using LibraryMgmtSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LibraryMgmtSystem.UnitTests")]

namespace LibraryMgmtSystem.Repositories
{
    /// <summary>
    /// AssignDetails repository
    /// </summary>
    internal class AssignDetailsRepository : IAssignDetailsRepository<AssignDetails> 
    {
        #region Public constants
        
        /// <summary>
        /// Total number of days a book can be borrowed
        /// </summary>
        public const int NoOfDaysBookToBeAssigned = 21;

        #endregion

        #region Private fields

        /// <summary>
        /// List of books
        /// </summary>
        private IList<AssignDetails> _borrowDetails = new List<AssignDetails>() {
            new AssignDetails() { Id = 1,  BookId = 2, StudentId = 1, DueDate = new DateTime(2019,02,26)},
            new AssignDetails() { Id = 2,  BookId = 5, StudentId = 2, DueDate = new DateTime(2019,03,20)},
            new AssignDetails() { Id = 3,  BookId = 6, StudentId = 3, DueDate = new DateTime(2019,03,20)},
            new AssignDetails() { Id = 4,  BookId = 7, StudentId = 4, DueDate = new DateTime(2019,03,23)},
            new AssignDetails() { Id = 5,  BookId = 1, StudentId = 4, DueDate = new DateTime(2019,02,23)},
        };

        #endregion

        #region Implementing IRepostiory

        /// <summary>
        /// Returns list of borrow details
        /// </summary>
        /// <returns>List of borrow details</returns>
        public IEnumerable<AssignDetails> GetAll()
        {
            return _borrowDetails;
        }

        /// <summary>
        /// Returns borrow details for the given book Id
        /// </summary>
        /// <param name="bookId">book Id</param>
        /// <returns>Returns borrow details if found, else returns null</returns>
        public AssignDetails Find(int bookId)
        {
            try
            {
                if (_borrowDetails.Where(x => x.BookId == bookId).Count() == 0)
                {
                    return null;
                }

                return _borrowDetails.Where(x => x.BookId == bookId).First();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns borrow details for the given book Id and studentId
        /// </summary>
        /// <param name="bookId">book Id</param>
        /// <param name="studentId">student Id</param> 
        /// <returns>Returns borrow details if found, else returns null</returns>
        public AssignDetails Find(int bookId, int studentId)
        {
            try
            {
                if (_borrowDetails.Where(x => x.BookId == bookId && x.StudentId == studentId).Count() == 0)
                {
                    return null;
                }

                return _borrowDetails.Where(x => x.BookId == bookId && x.StudentId == studentId).First();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
        #endregion
    }
}