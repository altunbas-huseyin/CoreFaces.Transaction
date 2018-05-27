using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreFaces.Transaction.UnitTest
{
    [TestClass]
    public class TransactionSchemaServiceTest : BaseTest
    {
        [TestMethod]
        public void DropTables()
        {
            bool result = transactionSchemaService.DropTables();
            Assert.AreEqual(result, true);
        }


        [TestMethod]
        public void EnsureCreated()
        {
            bool result = transactionSchemaService.EnsureCreated();
            Assert.AreEqual(result, true);
        }
    }
}
