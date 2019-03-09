using LibraryMgmtSystem.Models;

namespace LibraryMgmtSystem.Repositories
{
    /// <summary>
    /// Books repostiory interface
    /// </summary>
    public interface IBooksRepository<T> : IRepository<T>
    {
        /// <summary>
        /// Finds a book in the list 
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <returns>Returns a book if found, else returns null</returns>
        Book Find(int id);
    }
}
