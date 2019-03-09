using LibraryMgmtSystem.Models;
using System.Collections.Generic;

namespace LibraryMgmtSystem.Services
{
    /// <summary>
    /// Interface for Books retrieval
    /// </summary>
    public interface IBooksService
    {
        /// <summary>
        /// Retrieves list of books
        /// </summary>
        /// <returns>List of books</returns>
        IEnumerable<Book> GetAll();

        /// <summary>
        /// Returns the list of overdue books
        /// </summary>
        /// <returns>List of overdue books</returns>
        IEnumerable<Book> GetOverdueBooks();

        /// <summary>
        /// Checks whether the book in the list of books available in library
        /// </summary>
        /// <param name="bookId">book Id</param>
        /// <returns>True if book is available in the library, else false</returns>
        bool IsValidBook(int bookId);
    }
}
