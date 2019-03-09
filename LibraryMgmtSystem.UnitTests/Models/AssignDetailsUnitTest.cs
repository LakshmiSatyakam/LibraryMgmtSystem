using LibraryMgmtSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LibraryMgmtSystem.UnitTests.Models
{
    /// <summary>
    /// Unit test for AssignDetails model class
    /// </summary>
    [TestClass]
    public class AssignDetailsUnitTest
    {
        #region Test methods

        [TestMethod]
        public void Book_Test()
        {
            AssignDetails details = new AssignDetails() { Id = 1, BookId = 100, StudentId = 1000, DueDate = new DateTime(2018, 12,12)};
            Assert.IsTrue(details.Id == 1);
            Assert.IsTrue(details.BookId == 100);
            Assert.IsTrue(details.StudentId == 1000);
            Assert.IsTrue(details.DueDate.Year == 2018);
        }

        #endregion
    }
}
