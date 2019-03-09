using System.ComponentModel.DataAnnotations;

namespace LibraryMgmtSystem.Models
{
    /// <summary>
    /// Model class for AssignRequest
    /// </summary>
    public class AssignRequest
    {
        #region Public properties

        /// <summary>
        /// Student Id
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Student Id should be positive integer!")]
        public int StudentId { get; set; }

        /// <summary>
        /// BookId
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Book Id should be positive integer!")]
        public int BookId { get; set; } 

        #endregion
    }
}