using System;

namespace LibraryMgmtSystem.Models
{
    /// <summary>
    /// Model class for AssignDetails
    /// </summary>
    public class AssignDetails
    {
        #region Public properties

        /// <summary>
        /// Assign Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Book Id 
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Student Id who borrowed the book
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// DueDate of the book if it is borrowed
        /// </summary>
        public DateTime DueDate { get; set; } 

        #endregion
    }
}