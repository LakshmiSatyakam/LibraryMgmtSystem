using LibraryMgmtSystem.Controllers;
using LibraryMgmtSystem.Models;
using LibraryMgmtSystem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace LibraryMgmtSystem.UnitTests.Controllers
{
    /// <summary>
    /// Unit test class for BooksController
    /// </summary>
    [TestClass]
    public class BooksControllerUnitTest
    {
        #region Private fields

        /// <summary>
        /// Mock instance of IBooksSerivce
        /// </summary>
        private Mock<IBooksService> _mockBooksService;

        /// <summary>
        /// Instance of BooksController
        /// </summary>
        private BooksController _booksController; 

        #endregion

        #region TestInitialize

        [TestInitialize()]
        public void TestInitialize()
        {
            _mockBooksService = new Mock<IBooksService>();
            _booksController = new BooksController(_mockBooksService.Object);
        }

        #endregion

        #region Constructor test

        [TestMethod]
        public void Constructor_Test()
        {
            BooksController controller = new BooksController(_mockBooksService.Object);
            Assert.IsNotNull(controller);
        }

        #endregion

        #region Action method tests

        [TestMethod]
        public void GetAll_Test()
        {
            _mockBooksService.Setup(x => x.GetAll()).Returns(new List<Book> { new Book() { Id = 1, Name = "Test Book" } });

            IList<Book> books = _booksController.GetAll() as IList<Book>;
            Assert.IsNotNull(books);
            Assert.IsTrue(books.Count == 1);
        }


        [TestMethod]
        public void GetOverdue_Test()
        {
            _mockBooksService.Setup(x => x.GetOverdueBooks()).Returns(new List<Book> { new Book() { Id = 1, Name = "Test Book" } });

            IList<Book> books = _booksController.GetOverdue() as IList<Book>;
            Assert.IsNotNull(books);
            Assert.IsTrue(books.Count == 1);
        } 

        #endregion
    }
}
