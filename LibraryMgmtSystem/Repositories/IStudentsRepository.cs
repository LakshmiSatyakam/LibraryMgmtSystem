using LibraryMgmtSystem.Models;

namespace LibraryMgmtSystem.Repositories
{
    /// <summary>
    /// Students repostiory interface
    /// </summary>
    public interface IStudentsRepository<T> : IRepository<T>
    {
        /// <summary>
        /// Finds a student in the repository 
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <returns>Returns a student object if found, else returns null</returns>
        Student Find(int id);
    }
}
