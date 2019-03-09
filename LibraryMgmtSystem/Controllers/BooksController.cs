using LibraryMgmtSystem.Models;
using LibraryMgmtSystem.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace LibraryMgmtSystem.Controllers
{
    /// <summary>
    /// Books controller for getting list of books 
    /// and list of overdue books
    /// </summary>
    public class BooksController : ApiController
    {
        #region Private fields

        /// <summary>
        /// BooksService instance
        /// </summary>
        private IBooksService _bookServie;

        #endregion

        #region Construction

        public BooksController(IBooksService bookServie)
        {
            _bookServie = bookServie;
        }

        #endregion

        #region Action methods

        /// <summary>
        /// Gets a list of all the books in library
        /// </summary>
        /// <returns>Returns a list of books</returns>
        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
            return _bookServie.GetAll();
        }

        /// <summary>
        /// Gets a list of overdue books
        /// </summary>
        /// <returns>List of overdue books</returns>
        [Route("api/books/getoverdue")]
        [HttpGet()]
        public IEnumerable<Book> GetOverdue()
        {
            return _bookServie.GetOverdueBooks();
        } 

        #endregion
    }
}
