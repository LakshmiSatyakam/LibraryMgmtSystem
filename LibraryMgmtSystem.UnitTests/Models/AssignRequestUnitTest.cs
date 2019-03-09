using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryMgmtSystem.Models;

namespace LibraryMgmtSystem.UnitTests.Models
{
    /// <summary>
    /// Unit test for AssignRequest model class
    /// </summary>
    [TestClass]
    public class AssignRequestUnitTest
    {
        #region Test methods

        [TestMethod]
        public void Book_Test()
        {
            AssignRequest request = new AssignRequest() { StudentId = 1, BookId = 100 };
            Assert.IsTrue(request.StudentId == 1);
            Assert.IsTrue(request.BookId == 100);
        }

        #endregion
    }
}
