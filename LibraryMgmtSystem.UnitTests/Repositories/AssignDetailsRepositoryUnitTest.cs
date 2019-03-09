using LibraryMgmtSystem.Models;
using LibraryMgmtSystem.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LibraryMgmtSystem.UnitTests.Repositories
{
    /// <summary>
    /// Summary description for AssignDetailsRepositoryUnitTest
    /// </summary>
    [TestClass]
    public class AssignDetailsRepositoryUnitTest
    {
        #region Private fields

        /// <summary>
        /// Repository instance
        /// </summary>
        private AssignDetailsRepository _repository;

        #endregion

        #region TestInitialize

        [TestInitialize()]
        public void TestInitialize()
        {
            _repository = new AssignDetailsRepository();
        }

        #endregion

        #region Test methods

        [TestMethod]
        public void GetAll_Test()
        {
            IEnumerable<AssignDetails> details = _repository.GetAll();

            Assert.IsNotNull(details);
        }

        [TestMethod]
        public void Find_By_BookId_Null_Test()
        {
            AssignDetails details = _repository.Find(100);

            Assert.IsNull(details);
        }

        [TestMethod]
        public void Find_By_BookId_Valid_Book_Test()
        {
            AssignDetails details = _repository.Find(1);

            Assert.IsNotNull(details);
            Assert.IsTrue(details.BookId == 1);
        }

        [TestMethod]
        public void Find_Null_Test()
        {
            AssignDetails details = _repository.Find(100, 100);

            Assert.IsNull(details);
        }

        [TestMethod]
        public void Find_Valid_Book_Test()
        {
            AssignDetails details = _repository.Find(1, 4);

            Assert.IsNotNull(details);
            Assert.IsTrue(details.BookId == 1);
            Assert.IsTrue(details.StudentId == 4);
        }

        [TestMethod]
        public void NoOfDaysBookToBeAssigned_Test()
        {
            Assert.IsTrue(AssignDetailsRepository.NoOfDaysBookToBeAssigned == 21);
        }

        #endregion
    }
}

