using LibraryMgmtSystem.Models;
using LibraryMgmtSystem.Services;
using System.Linq;
using System.Web.Http;

namespace LibraryMgmtSystem.Controllers
{
    /// <summary>
    /// Controller for Books renew actions
    /// </summary>
    public class BooksRenewController : ApiController
    {
        #region Private fields

        /// <summary>
        /// BooksService instance
        /// </summary>
        IBooksService _bookService;

        /// <summary>
        /// StudentsService instance
        /// </summary>
        IStudentsService _studentsService;

        /// <summary>
        /// BooksRenewService instance
        /// </summary>
        IBooksRenewService _booksRenewServie;

        #endregion

        #region Construction

        public BooksRenewController(IBooksService bookService, IStudentsService studentsService, IBooksRenewService booksRenewServie)
        {
            _bookService = bookService;
            _studentsService = studentsService;
            _booksRenewServie = booksRenewServie;
        }

        #endregion

        #region Action methods

        /// <summary>
        /// Renews a book
        /// Validates on studentId, bookId -- for non-positive numbers
        /// Checks for whether the bookId is available in the library
        /// and checks for book is borrowed by same student before renewal
        /// </summary>
        /// <param name="request">Request containing BookId and StudentId</param>
        /// <returns>Successful message if borrow was successful, else returns error message</returns>
        [Route("api/booksrenew/renewbook")]
        [HttpPut]
        public string RenewBook([FromBody] AssignRequest request)
        {
            if (request == null)
            {
                return "Renew request is null";
            }

            if (!ModelState.IsValid)
            {
                return string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }

            if (!_bookService.IsValidBook(request.BookId))
            {
                return "The requested book is not available in the library!";
            }

            if (!_studentsService.IsValidStudent(request.StudentId))
            {
                return "Invalid Student Id!";
            }

            if (!_booksRenewServie.CanRenewBook(request.BookId))
            {
                return "Book is not assigned to the student, cannot renew!";
            }

            if (!_booksRenewServie.IsValidRenewal(request.BookId, request.StudentId))
            {
                return "Book is assigned to some other student; this renewal is not valid!";
            }

            if (_booksRenewServie.RenewBook(request.BookId, request.StudentId))
            {
                return "Book renewed successfully";
            }

            return "Book could not be renewed";
        } 

        #endregion
    }
}
