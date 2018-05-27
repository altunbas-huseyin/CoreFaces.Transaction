using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CoreFaces.Transaction.UnitTest
{
    [TestClass]
    public class TransactionServiceTest : BaseTest
    {
        [TestMethod]
        public void AddTransaction()
        {
            Models.Domain.Transaction transaction = new Models.Domain.Transaction { Amount=10,  Currency= Helper.Enums.Currency.POINT,  StatusId=2, UserId=Guid.NewGuid() };
            Guid result = _transactionServiceService.Save(transaction);
            
        }
    }
}
