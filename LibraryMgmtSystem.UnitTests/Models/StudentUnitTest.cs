using LibraryMgmtSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryMgmtSystem.UnitTests.Models
{
    /// <summary>
    /// Unit test for Student model class
    /// </summary>
    [TestClass]
    public class StudentUnitTest
    {
        #region Test methods

        [TestMethod]
        public void Student_Test()
        {
            Student student = new Student() { Id = 1, Name = "Aaaa" };
            Assert.IsTrue(student.Id == 1);
            Assert.IsTrue(student.Name == "Aaaa");
        }

        #endregion
    }
}
