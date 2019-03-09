using LibraryMgmtSystem.Controllers;
using LibraryMgmtSystem.Models;
using LibraryMgmtSystem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LibraryMgmtSystem.UnitTests.Controllers
{
    /// <summary>
    /// Unit test for BooksRenewController
    /// </summary>
    [TestClass]
    public class BooksRenewControllerUnitTest
    {
        #region Private fields

        /// <summary>
        /// Mock instance of IBooksService
        /// </summary>
        private Mock<IBooksService> _mockBooksService;

        /// <summary>
        /// Mock instance of IStudentsService
        /// </summary>
        private Mock<IStudentsService> _mockStudentsService;

        /// <summary>
        /// Mock instance of IBooksRenewService
        /// </summary>
        private Mock<IBooksRenewService> _mockBooksRenewService;

        /// <summary>
        /// Controller instance
        /// </summary>
        private BooksRenewController _controller;

        #endregion

        #region TestInitialize

        [TestInitialize()]
        public void TestInitialize()
        {
            _mockBooksService = new Mock<IBooksService>();
            _mockStudentsService = new Mock<IStudentsService>();
            _mockBooksRenewService = new Mock<IBooksRenewService>();
            _controller = new BooksRenewController(_mockBooksService.Object, _mockStudentsService.Object, _mockBooksRenewService.Object);
        }

        #endregion

        #region Test methods

        #region Constructor tests

        [TestMethod]
        public void Constructor_Test()
        {
            BooksRenewController controller = new BooksRenewController(_mockBooksService.Object, _mockStudentsService.Object,_mockBooksRenewService.Object);
            Assert.IsNotNull(controller);
        }

        #endregion

        #region Action method tests

        [TestMethod]
        public void RenewBook_Null_Input_Test()
        {
            string result = _controller.RenewBook(null);
            Assert.IsTrue(result == "Renew request is null");
        }

        [TestMethod]
        public void RenewBook_Empty_Request_Test()
        {
            AssignRequest request = new AssignRequest();

            // mimic the behaviour of the model binder which is responsible for Validating the Model
            var validationContext = new ValidationContext(request, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(request, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                _controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            string result = _controller.RenewBook(request);

            Assert.IsTrue(result == "Student Id should be positive integer! | Book Id should be positive integer!");
        }

        [TestMethod]
        public void RenewBook_Negative_BookId_Test()
        {
            AssignRequest request = new AssignRequest() { StudentId = 100, BookId = -10 };

            // mimic the behaviour of the model binder which is responsible for Validating the Model
            var validationContext = new ValidationContext(request, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(request, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                _controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            string result = _controller.RenewBook(request);

            Assert.IsTrue(result == "Book Id should be positive integer!");
        }

        [TestMethod]
        public void RenewBook_InValid_BookId_Test()
        {
            _mockBooksService.Setup(x => x.IsValidBook(100)).Returns(false);
            string result = _controller.RenewBook(new AssignRequest() { StudentId = 100, BookId = 10 });
            Assert.IsTrue(result == "The requested book is not available in the library!");
        }

        [TestMethod]
        public void RenewBook_InValid_StudentId_Test()
        {
            _mockBooksService.Setup(x => x.IsValidBook(10)).Returns(true);
            _mockStudentsService.Setup(x => x.IsValidStudent(100)).Returns(false);

            string result = _controller.RenewBook(new AssignRequest() { StudentId = 100, BookId = 10 });
            Assert.IsTrue(result == "Invalid Student Id!");
        }

        [TestMethod]
        public void RenewBook_Negative_StudentId_Test()
        {
            AssignRequest request = new AssignRequest() { StudentId = -1100, BookId = 10 };

            // mimic the behaviour of the model binder which is responsible for Validating the Model
            var validationContext = new ValidationContext(request, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(request, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                _controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            string result = _controller.RenewBook(request);

            Assert.IsTrue(result == "Student Id should be positive integer!");
        }

        [TestMethod]
        public void RenewBook_InValid_Request_Test()
        {
            AssignRequest request = new AssignRequest() { StudentId = -1100, BookId = -10 };

            // mimic the behaviour of the model binder which is responsible for Validating the Model
            var validationContext = new ValidationContext(request, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(request, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                _controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            string result = _controller.RenewBook(request);

            Assert.IsTrue(result == "Student Id should be positive integer! | Book Id should be positive integer!");
        }

        [TestMethod]
        public void RenewBook_CanRenewBook_Failure_Test()
        {
            _mockBooksService.Setup(x => x.IsValidBook(100)).Returns(true);
            _mockStudentsService.Setup(x => x.IsValidStudent(100)).Returns(true);
            _mockBooksRenewService.Setup(x => x.CanRenewBook(100)).Returns(false);

            string result = _controller.RenewBook(new AssignRequest() { StudentId = 100, BookId = 100 });
            Assert.IsTrue(result == "Book is not assigned to the student, cannot renew!");
        }

        [TestMethod]
        public void RenewBook_Assigned_By_Someone_Else_Test()
        {
            _mockBooksService.Setup(x => x.IsValidBook(100)).Returns(true);
            _mockStudentsService.Setup(x => x.IsValidStudent(100)).Returns(true);
            _mockBooksRenewService.Setup(x => x.CanRenewBook(100)).Returns(true);
            _mockBooksRenewService.Setup(x => x.IsValidRenewal(100, 100)).Returns(false);

            string result = _controller.RenewBook(new AssignRequest() { StudentId = 100, BookId = 100 });
            Assert.IsTrue(result == "Book is assigned to some other student; this renewal is not valid!");
        }

        [TestMethod]
        public void RenewBook_Success_Test()
        {
            _mockBooksService.Setup(x => x.IsValidBook(100)).Returns(true);
            _mockStudentsService.Setup(x => x.IsValidStudent(10)).Returns(true);
            _mockBooksRenewService.Setup(x => x.CanRenewBook(100)).Returns(true);
            _mockBooksRenewService.Setup(x => x.IsValidRenewal(100, 10)).Returns(true);
            _mockBooksRenewService.Setup(x => x.RenewBook(100, 10)).Returns(true);

            string result = _controller.RenewBook(new AssignRequest() { StudentId = 10, BookId = 100 });
            Assert.IsTrue(result == "Book renewed successfully");
        }

        [TestMethod]
        public void RenewBook_Failure_Test()
        {
            _mockBooksService.Setup(x => x.IsValidBook(100)).Returns(true);
            _mockStudentsService.Setup(x => x.IsValidStudent(10)).Returns(true);
            _mockBooksRenewService.Setup(x => x.CanRenewBook(100)).Returns(true);
            _mockBooksRenewService.Setup(x => x.IsValidRenewal(100,10)).Returns(true);
            _mockBooksRenewService.Setup(x => x.RenewBook(100, 10)).Returns(false);

            string result = _controller.RenewBook(new AssignRequest() { StudentId = 10, BookId = 100 });
            Assert.IsTrue(result == "Book could not be renewed");
        }
        #endregion

        #endregion
    }
}
