
namespace LibraryMgmtSystem.Services
{
    /// <summary>
    /// Interface for Books borrow service
    /// </summary>
    public interface IBooksAssignService
    {
        /// <summary>
        /// Checks whether a book can be borrowed or not
        /// </summary>
        /// <param name="bookId">book Id</param>
        /// <returns>Returns true if book can be borrowed, else false</returns>
        bool CanAssignBook(int bookId);

        /// <summary>
        /// Assigns a book
        /// </summary>
        /// <param name="studentId">student Id</param>
        /// <param name="bookId">book Id</param>
        /// <returns>Returns true if borrowing was successful, else false</returns>
        bool AssignBook(int studentId, int bookId);
    }
}
