
namespace LibraryMgmtSystem.Services
{
    /// <summary>
    /// Interface for Books renew service
    /// </summary>
    public interface IBooksRenewService
    {
        /// <summary>
        /// Checks whether a book can be renewed or not
        /// </summary>
        /// <param name="bookId">book Id</param>
        /// <returns>Returns true if book can be renewed, else false</returns>
        bool CanRenewBook(int bookId);

        /// <summary>
        /// Checks whether book is borrowed by the same student requesting for renewal
        /// </summary>
        /// <param name="bookId">book Id</param>
        /// <param name="studentId">student Id</param>
        /// <returns>Returns true if book can be renewed, else false</returns>
        bool IsValidRenewal(int bookId, int studentId);

        /// <summary>
        /// Renews a book
        /// </summary>
        /// <param name="bookId">book Id</param>
        /// <param name="studentId">student Id</param>
        /// <returns>Returns true if book renewal was successfull, else false</returns>
        bool RenewBook(int bookId, int studentId);
    }
}
