
namespace LibraryMgmtSystem.Services
{
    /// <summary>
    /// Interface for Students
    /// </summary>
    public interface IStudentsService
    {
        /// <summary>
        /// Validates whether student is valid or not
        /// </summary>
        /// <param name="studentId">student Id</param>
        /// <returns>Returns true if student is found in repostiory, else false</returns>
        bool IsValidStudent(int studentId);
    }
}
