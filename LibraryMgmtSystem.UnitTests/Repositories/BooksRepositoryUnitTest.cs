using LibraryMgmtSystem.Models;
using LibraryMgmtSystem.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LibraryMgmtSystem.UnitTests.Repositories
{
    /// <summary>
    /// Unit test for BooksRepository
    /// </summary>
    [TestClass]
    public class BooksRepositoryUnitTest
    {
        #region Private fields

        /// <summary>
        /// Repository instance
        /// </summary>
        private BooksRepository _repository;

        #endregion

        #region TestInitialize

        [TestInitialize()]
        public void TestInitialize()
        {
            _repository = new BooksRepository();
        }

        #endregion

        #region Test methods

        [TestMethod]
        public void GetAll_Test()
        {
            IEnumerable<Book> books = _repository.GetAll();

            Assert.IsNotNull(books);
        }

        [TestMethod]
        public void Find_Null_Test()
        {
            Book book = _repository.Find(100);

            Assert.IsNull(book);
        }

        [TestMethod]
        public void Find_Valid_Book_Test()
        {
            Book book = _repository.Find(1);

            Assert.IsNotNull(book);
            Assert.IsTrue(book.Id == 1);
        }

        #endregion
    }
}
