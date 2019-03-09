using LibraryMgmtSystem.Models;
using LibraryMgmtSystem.Repositories;
using LibraryMgmtSystem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace LibraryMgmtSystem.UnitTests.Services
{
    /// <summary>
    /// Unit test for BooksAssignService
    /// </summary>
    [TestClass]
    public class BooksAssignServiceUnitTest
    {
        #region Private fields

        /// <summary>
        /// Mock instance of IBooksRepository
        /// </summary>
        private Mock<IBooksRepository<Book>> _mockBooksRepository;

        /// <summary>
        /// Mock instance of IBooksRepository
        /// </summary>
        private Mock<IAssignDetailsRepository<AssignDetails>> _mockAssignDetailsRepository;

        /// <summary>
        /// Service instance
        /// </summary>
        private BooksAssignService _serive;

        #endregion

        #region TestInitialize

        [TestInitialize()]
        public void TestInitialize()
        {
            _mockBooksRepository = new Mock<IBooksRepository<Book>>();
            _mockAssignDetailsRepository = new Mock<IAssignDetailsRepository<AssignDetails>>();
            _serive = new BooksAssignService(_mockBooksRepository.Object, _mockAssignDetailsRepository.Object);
        }

        #endregion

        #region Test methods

        #region Constructor tests

        [TestMethod]
        public void Constructor_Test()
        {
            BooksAssignService service = new BooksAssignService(_mockBooksRepository.Object, _mockAssignDetailsRepository.Object);
            Assert.IsNotNull(service);
        }

        #endregion

        #region Service method tests

        [TestMethod]
        public void CanAssignBook_False_Test()
        {
            Book book = null;
            _mockBooksRepository.Setup(x => x.Find(100)).Returns(book);

            bool result = _serive.CanAssignBook(100);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanAssignBook_Assigned_By_Someone_Test()
        {
            _mockAssignDetailsRepository.Setup(x => x.Find(100)).Returns(new AssignDetails());

            bool result = _serive.CanAssignBook(100);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanAssignBook_True_Test()
        {
            _mockBooksRepository.Setup(x => x.Find(100)).Returns(new Book() { Id = 100 });

            bool result = _serive.CanAssignBook(100);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AssignBook_False_Test()
        {
            Book book = null;
            _mockBooksRepository.Setup(x => x.Find(100)).Returns(book);

            bool result = _serive.AssignBook(10, 100);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AssignBook_True_Test()
        {
            _mockBooksRepository.Setup(x => x.Find(100)).Returns(new Book());
            _mockAssignDetailsRepository.Setup(x => x.GetAll()).Returns(new List<AssignDetails>());

            bool result = _serive.AssignBook(10, 100);
            Assert.IsTrue(result);
        }

        #endregion

        #endregion
    }
}