using LibraryMgmtSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryMgmtSystem.UnitTests.Models
{
    /// <summary>
    /// Unittest for Book model class
    /// </summary>
    [TestClass]
    public class BookUnitTest
    {
        #region Test methods

        [TestMethod]
        public void Book_Test()
        {
            Book book = new Book() { Id = 1, Name = "Test book" };
            Assert.IsTrue(book.Id == 1);
            Assert.IsTrue(book.Name == "Test book");
        } 

        #endregion
    }
}
