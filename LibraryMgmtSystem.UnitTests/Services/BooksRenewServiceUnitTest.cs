using LibraryMgmtSystem.Models;
using LibraryMgmtSystem.Repositories;
using LibraryMgmtSystem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LibraryMgmtSystem.UnitTests.Services
{
    /// <summary>
    /// Unit test for BooksRenewService
    /// </summary>
    [TestClass]
    public class BooksRenewServiceUnitTest
    {
        #region Private fields
        
        /// <summary>
        /// Mock instance of IAssignDetailsRepository
        /// </summary>
        private Mock<IAssignDetailsRepository<AssignDetails>> _mockAssignDetailsRepository;

        /// <summary>
        /// Service instance
        /// </summary>
        private BooksRenewService _serive;

        #endregion

        #region TestInitialize

        [TestInitialize()]
        public void TestInitialize()
        {
            _mockAssignDetailsRepository = new Mock<IAssignDetailsRepository<AssignDetails>>();
            _serive = new BooksRenewService(_mockAssignDetailsRepository.Object);
        }

        #endregion

        #region Test methods

        #region Constructor tests

        [TestMethod]
        public void Constructor_Test()
        {
            BooksRenewService service = new BooksRenewService(_mockAssignDetailsRepository.Object);
            Assert.IsNotNull(service);
        }

        #endregion

        #region Service method tests

        [TestMethod]
        public void CanRenewBook_False_Test()
        {
            AssignDetails details = null;
            _mockAssignDetailsRepository.Setup(x => x.Find(100)).Returns(details);

            bool result = _serive.CanRenewBook(100);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanRenewBook_True_Test()
        {
            _mockAssignDetailsRepository.Setup(x => x.Find(100)).Returns(new AssignDetails());

            bool result = _serive.CanRenewBook(100);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidRenewal_False_Test()
        {
            AssignDetails details = null;
            _mockAssignDetailsRepository.Setup(x => x.Find(10)).Returns(details);

            bool result = _serive.IsValidRenewal(10, 100);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidRenewal_Assigned_By_Someone_Else_Test()
        {
            _mockAssignDetailsRepository.Setup(x => x.Find(2)).Returns(new AssignDetails() { StudentId = 3, BookId = 2});

            bool result = _serive.IsValidRenewal(2, 100);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidRenewal_True_Test()
        {
            _mockAssignDetailsRepository.Setup(x => x.Find(10, 100)).Returns(new AssignDetails() { StudentId = 100, BookId = 10 });

            bool result = _serive.IsValidRenewal(10, 100);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RenewBook_Invalid_AssignDetails_Test()
        {
            AssignDetails details = null;
            _mockAssignDetailsRepository.Setup(x => x.Find(2)).Returns(details);

            bool result = _serive.RenewBook(2, 100);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RenewBook_Success_Test()
        {
            _mockAssignDetailsRepository.Setup(x => x.Find(10, 100)).Returns(new AssignDetails() { StudentId = 100, BookId = 10 });

            bool result = _serive.RenewBook(10, 100);
            Assert.IsTrue(result);
        }

        #endregion

        #endregion
    }
}
