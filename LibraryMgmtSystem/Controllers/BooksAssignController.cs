using LibraryMgmtSystem.Models;
using LibraryMgmtSystem.Services;
using System.Linq;
using System.Web.Http;

namespace LibraryMgmtSystem.Controllers
{
    /// <summary>
    /// Controller for Books borrow actions
    /// </summary>
    public class BooksAssignController : ApiController
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
        /// BooksAssignService instance
        /// </summary>
        IBooksAssignService _booksAssignServie;

        #endregion

        #region Constructor

        public BooksAssignController(IBooksService bookService, IStudentsService studentsService, IBooksAssignService booksAssignServie)
        {
            _bookService = bookService;
            _studentsService = studentsService;
            _booksAssignServie = booksAssignServie;
        }

        #endregion

        #region Action methods

        /// <summary>
        /// Assigns a book
        /// Validates on studentId, bookId -- for non-positive numbers
        /// Checks for whether the bookId is available in the library
        /// and checks for book is not borrowed by anyone else
        /// </summary>
        /// <param name="request">Request object containing BookId and Student Id</param>
        /// <returns>Successful message if borrow was successful, else returns error message</returns>
        [Route("api/booksassign/assignbook")]
        [HttpPost]
        public string AssignBook([FromBody]AssignRequest request)
        {
            if (request == null)
            {
                return "Assign request is null";
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

            if (!_booksAssignServie.CanAssignBook(request.BookId))
            {
                return "Book is already assigned!";
            }

            if (_booksAssignServie.AssignBook(request.StudentId, request.BookId))
            {
                return "Book assigned successfully";
            }

            return "Book could not be assigned";
        }

        #endregion
    }
}
