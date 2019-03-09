using LibraryMgmtSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LibraryMgmtSystem.UnitTests")]

namespace LibraryMgmtSystem.Repositories
{
    /// <summary>
    /// Students repository
    /// </summary>
    internal class StudentsRepository : IStudentsRepository<Student>
    {
        #region Private fields

        /// <summary>
        /// List of students
        /// </summary>
        private IList<Student> _students = new List<Student>() {
            new Student() { Id = 1, Name = "Amar" },
            new Student() { Id = 2, Name = "Akbar" },
            new Student() { Id = 3, Name = "Antony" },
            new Student() { Id = 4, Name = "Ram" },
            new Student() { Id = 5, Name = "Rahim" },
            new Student() { Id = 6, Name = "Robin" },
            new Student() { Id = 7, Name = "Prachu" },
            new Student() { Id = 8, Name = "Pillip" },
        };

        #endregion

        #region Implementation of IStudentsRepostiory

        /// <summary>
        /// Returns list of students
        /// </summary>
        /// <returns>List of students</returns>
        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        /// <summary>
        /// Finds a student
        /// </summary>
        /// <param name="id">Student Id to be found</param>
        /// <returns>Returns student object if found, else returns null</returns>
        public Student Find(int id)
        {
            try
            {
                if (_students.Where(x => x.Id == id).Count() == 0)
                {
                    return null;
                }

                return _students.Where(x => x.Id == id).First();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        #endregion
    }
}