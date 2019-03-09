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
    /// Unit test for BooksAssignController
    /// </summary>
    [TestClass]
    public class BooksAssignControllerUnitTest
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
        /// Mock instance of IBooksAssignService
        /// </summary>
        private Mock<IBooksAssignService> _mockBooksAssignService;

        /// <summary>
        /// Controller instance
        /// </summary>
        private BooksAssignController _controller; 

        #endregion

        #region TestInitialize

        [TestInitialize()]
        public void TestInitialize()
        {
            _mockBooksService = new Mock<IBooksService>();
            _mockStudentsService = new Mock<IStudentsService>();
            _mockBooksAssignService = new Mock<IBooksAssignService>();
            _controller = new BooksAssignController(_mockBooksService.Object, _mockStudentsService.Object, _mockBooksAssignService.Object);
        }

        #endregion

        #region Test methods

        #region Constructor tests

        [TestMethod]
        public void Constructor_Test()
        {
            BooksAssignController controller = new BooksAssignController(_mockBooksService.Object, _mockStudentsService.Object, _mockBooksAssignService.Object);
            Assert.IsNotNull(controller);
        }

        #endregion

        #region Action method tests

        [TestMethod]
        public void AssignBook_Null_Input_Test()
        {
            string result = _controller.AssignBook(null);
            Assert.IsTrue(result == "Assign request is null");
        }

        [TestMethod]
        public void AssignBook_Empty_Request_Test()
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

            string result = _controller.AssignBook(request);

            Assert.IsTrue(result == "Student Id should be positive integer! | Book Id should be positive integer!");
        }

        [TestMethod]
        public void AssignBook_Negative_BookId_Test()
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

            string result = _controller.AssignBook(request);

            Assert.IsTrue(result == "Book Id should be positive integer!");
        }

        [TestMethod]
        public void AssignBook_InValid_BookId_Test()
        {
            _mockBooksService.Setup(x => x.IsValidBook(100)).Returns(false);
            string result = _controller.AssignBook(new AssignRequest() { StudentId = 100, BookId = 100 });
            Assert.IsTrue(result == "The requested book is not available in the library!");
        }

        [TestMethod]
        public void AssignBook_InValid_StudentId_Test()
        {
            _mockBooksService.Setup(x => x.IsValidBook(100)).Returns(true);
            _mockStudentsService.Setup(x => x.IsValidStudent(100)).Returns(false);

            string result = _controller.AssignBook(new AssignRequest() { StudentId = 100, BookId = 100 });
            Assert.IsTrue(result == "Invalid Student Id!");
        }

        [TestMethod]
        public void AssignBook_Negative_StudentId_Test()
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

            string result = _controller.AssignBook(request);

            Assert.IsTrue(result == "Student Id should be positive integer!");
        }

        [TestMethod]
        public void AssignBook_InValid_Request_Test()
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

            string result = _controller.AssignBook(request);

            Assert.IsTrue(result == "Student Id should be positive integer! | Book Id should be positive integer!");
        }

        [TestMethod]
        public void AssignBook_Book_Already_Assigned_Test()
        {
            _mockBooksService.Setup(x => x.IsValidBook(100)).Returns(true);
            _mockStudentsService.Setup(x => x.IsValidStudent(100)).Returns(true);
            _mockBooksAssignService.Setup(x => x.CanAssignBook(100)).Returns(false);

            string result = _controller.AssignBook(new AssignRequest() { StudentId = 100, BookId = 100 });
            Assert.IsTrue(result == "Book is already assigned!");
        }

        [TestMethod]
        public void AssignBook_Success_Test()
        {
            _mockBooksService.Setup(x => x.IsValidBook(100)).Returns(true);
            _mockStudentsService.Setup(x => x.IsValidStudent(10)).Returns(true);
            _mockBooksAssignService.Setup(x => x.CanAssignBook(100)).Returns(true);
            _mockBooksAssignService.Setup(x => x.AssignBook(10, 100)).Returns(true);

            string result = _controller.AssignBook(new AssignRequest() { StudentId = 10, BookId = 100 });
            Assert.IsTrue(result == "Book assigned successfully");
        }

        [TestMethod]
        public void AssignBook_Failure_Test()
        {
            _mockBooksService.Setup(x => x.IsValidBook(100)).Returns(true);
            _mockStudentsService.Setup(x => x.IsValidStudent(10)).Returns(true);
            _mockBooksAssignService.Setup(x => x.CanAssignBook(100)).Returns(true);
            _mockBooksAssignService.Setup(x => x.AssignBook(10, 100)).Returns(false);

            string result = _controller.AssignBook(new AssignRequest() { StudentId = 10, BookId = 100 });
            Assert.IsTrue(result == "Book could not be assigned");
        }
        #endregion

        #endregion
    }
}
