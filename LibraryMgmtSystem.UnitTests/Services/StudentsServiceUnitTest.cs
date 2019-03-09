using LibraryMgmtSystem.Models;
using LibraryMgmtSystem.Repositories;
using LibraryMgmtSystem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LibraryMgmtSystem.UnitTests.Services
{
    /// <summary>
    /// Unit test for StudentsService
    /// </summary>
    [TestClass]
    public class StudentsServiceUnitTest
    {
        #region Private fields

        /// <summary>
        /// Mock instance of IStudentsRepository
        /// </summary>
        private Mock<IStudentsRepository<Student>> _mockStudentsRepository;

        /// <summary>
        /// Service instance
        /// </summary>
        private StudentsService _serive;

        #endregion

        #region TestInitialize

        [TestInitialize()]
        public void TestInitialize()
        {
            _mockStudentsRepository = new Mock<IStudentsRepository<Student>>();
            _serive = new StudentsService(_mockStudentsRepository.Object);
        }

        #endregion

        #region Test methods

        #region Constructor tests

        [TestMethod]
        public void Constructor_Test()
        {
            StudentsService service = new StudentsService(_mockStudentsRepository.Object);
            Assert.IsNotNull(service);
        }

        #endregion

        #region Service method tests

        [TestMethod]
        public void IsValidStudent_True_Test()
        {
            _mockStudentsRepository.Setup(x => x.Find(100)).Returns(new Student());
            bool result = _serive.IsValidStudent(100);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidStudent_False_Test()
        {
            Student student = null;
            _mockStudentsRepository.Setup(x => x.Find(100)).Returns(student);

            bool result = _serive.IsValidStudent(100);
            Assert.IsFalse(result);
        }

        #endregion

        #endregion
    }
}
