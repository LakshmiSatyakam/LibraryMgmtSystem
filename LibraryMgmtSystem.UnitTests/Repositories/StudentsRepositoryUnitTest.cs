using LibraryMgmtSystem.Models;
using LibraryMgmtSystem.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LibraryMgmtSystem.UnitTests.Repositories
{
    /// <summary>
    /// Unit test for StudentsRepository
    /// </summary>
    [TestClass]
    public class StudentsRepositoryUnitTest
    {
        #region Private fields

        /// <summary>
        /// Repository instance
        /// </summary>
        private StudentsRepository _repository;

        #endregion

        #region TestInitialize

        [TestInitialize()]
        public void TestInitialize()
        {
            _repository = new StudentsRepository();
        }

        #endregion

        #region Test methods

        [TestMethod]
        public void GetAll_Test()
        {
            IEnumerable<Student> students = _repository.GetAll();

            Assert.IsNotNull(students);
        }

        [TestMethod]
        public void Find_Null_Test()
        {
            Student book = _repository.Find(100);

            Assert.IsNull(book);
        }

        [TestMethod]
        public void Find_Valid_Student_Test()
        {
            Student book = _repository.Find(1);

            Assert.IsNotNull(book);
            Assert.IsTrue(book.Id == 1);
        }

        #endregion
    }
}
