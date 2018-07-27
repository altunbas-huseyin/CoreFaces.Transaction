
using CoreFaces.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Transaction.Models.Domain
{
    public class Transaction : EntityBase
    {
        public Guid UserId { get; set; }
        public string TableName { get; set; } = "";
        public string TableRef { get; set; } = "";
        public Guid AreaId { get; set; } = default(Guid);
        public Guid OrderId { get; set; }= default(Guid);
        public string TransactionNumber { get; set; } = "";
        public Enums.Currency Currency { get; set; }
        public Enums.TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
