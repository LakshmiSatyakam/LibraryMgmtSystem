using LibraryMgmtSystem.Models;
using LibraryMgmtSystem.Repositories;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LibraryMgmtSystem.UnitTests")]

namespace LibraryMgmtSystem.Services
{
    /// <summary>
    /// StudentsService class
    /// </summary>
    internal class StudentsService : IStudentsService
    {
        #region Private fields

        /// <summary>
        /// StudentsRepository instance
        /// </summary>
        private IStudentsRepository<Student> _studentsRepostiory; 

        #endregion

        #region Construction

        public StudentsService(IStudentsRepository<Student> studentsRepostiory)
        {
            _studentsRepostiory = studentsRepostiory;
        }

        #endregion

        #region Implementing IBooksService

        /// <summary>
        /// Validates whether student is valid or not
        /// </summary>
        /// <param name="studentId">student Id</param>
        /// <returns>Returns true if student is found in repostiory, else false</returns>
        public bool IsValidStudent(int studentId)
        {
            return _studentsRepostiory.Find(studentId) != null;
        }

        #endregion
    }
}