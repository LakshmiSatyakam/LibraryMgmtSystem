using LibraryMgmtSystem.Models;

namespace LibraryMgmtSystem.Repositories
{
    /// <summary>
    /// Interface for managing Book borrows details
    /// </summary>
    public interface IAssignDetailsRepository<T> : IRepository<T>
    {
        /// <summary>
        /// Returns borrow details for the given book Id
        /// </summary>
        /// <param name="bookId">book Id</param>
        /// <returns>Returns borrow details if found, else returns null</returns>
        AssignDetails Find(int bookId);

        /// <summary>
        /// Returns borrow details for the given book Id and studentId
        /// </summary>
        /// <param name="bookId">book Id</param>
        /// <param name="studentId">student Id</param> 
        /// <returns>Returns borrow details if found, else returns null</returns>
        AssignDetails Find(int bookId, int studentId);
    }
}
