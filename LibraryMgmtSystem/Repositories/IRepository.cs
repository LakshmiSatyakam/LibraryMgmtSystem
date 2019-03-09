using System.Collections.Generic;

namespace LibraryMgmtSystem.Repositories
{
    /// <summary>
    /// Interface for repository of a collection
    /// </summary>
    public interface IRepository<T>
    {
        /// <summary>
        /// Returns list of all objects in the collection
        /// </summary>
        /// <returns>List of objects</returns>
        IEnumerable<T> GetAll(); 
    }
}
