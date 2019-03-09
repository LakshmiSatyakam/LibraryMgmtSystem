using LibraryMgmtSystem.Models;
using LibraryMgmtSystem.Repositories;
using LibraryMgmtSystem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace LibraryMgmtSystem.UnitTests.Services
{
    /// <summary>
    /// Unit test for BooksService
    /// </summary>
    [TestClass]
    public class BooksServiceUnitTest
    {
        #region Private fields

        /// <summary>
        /// Mock instance of IBooksRepository
        /// </summary>
        private Mock<IBooksRepository<Book>> _mockBooksRepository;

        /// <summary>
        /// Mock instance of IAssignDetailsRepository
        /// </summary>
        private Mock<IAssignDetailsRepository<AssignDetails>> _mockAssignDetailsRepository;

        /// <summary>
        /// Service instance
        /// </summary>
        private BooksService _booksSerive;

        #endregion

        #region TestInitialize

        [TestInitialize()]
        public void TestInitialize()
        {
            _mockBooksRepository = new Mock<IBooksRepository<Book>>();
            _mockAssignDetailsRepository = new Mock<IAssignDetailsRepository<AssignDetails>>();
            _booksSerive = new BooksService(_mockBooksRepository.Object, _mockAssignDetailsRepository.Object);
        }

        #endregion

        #region Test methods

        #region Constructor tests

        [TestMethod]
        public void Constructor_Test()
        {
            BooksService service = new BooksService(_mockBooksRepository.Object, _mockAssignDetailsRepository.Object);
            Assert.IsNotNull(service);
        }

        #endregion

        #region Service method tests

        [TestMethod]
        public void GetAll_Books_Test()
        {
            _mockBooksRepository.Setup(x => x.GetAll()).Returns(new List<Book> { new Book() { Id = 1, Name = "Test Book" } });

            IEnumerable<Book> books = _booksSerive.GetAll();
            Assert.IsNotNull(books);
        }

        [TestMethod]
        public void GetAll_Books_Overdue_Test()
        {
            _mockBooksRepository.Setup(x => x.GetAll()).Returns(new List<Book> { new Book() { Id = 1, Name = "Test Book" } });
            _mockAssignDetailsRepository.Setup(x => x.GetAll()).Returns(new List<AssignDetails> { new AssignDetails() { Id = 1, BookId = 1, StudentId = 100, DueDate=new DateTime(2018,12,12) } });

            IEnumerable<Book> books = _booksSerive.GetOverdueBooks();
            Assert.IsNotNull(books);
        }

        [TestMethod]
        public void GetAll_Books_Overdue_NullException_Test()
        {
            IList<Book> list = null;
            _mockBooksRepository.Setup(x => x.GetAll()).Returns(list);
            _mockAssignDetailsRepository.Setup(x => x.GetAll()).Returns(new List<AssignDetails> { new AssignDetails() { Id = 1, BookId = 1, StudentId = 100, DueDate = new DateTime(2018, 12, 12) } });

            IEnumerable<Book> books = _booksSerive.GetOverdueBooks();
            Assert.IsNotNull(books);
        }

        [TestMethod]
        public void IsValidBook_True_Test()
        {
            _mockBooksRepository.Setup(x => x.Find(100)).Returns(new Book());
            bool result = _booksSerive.IsValidBook(100);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidBook_False_Test()
        {
            Book book = null;
            _mockBooksRepository.Setup(x => x.Find(100)).Returns(book);

            bool result = _booksSerive.IsValidBook(100);
            Assert.IsFalse(result);
        }

        #endregion

        #endregion
    }
}