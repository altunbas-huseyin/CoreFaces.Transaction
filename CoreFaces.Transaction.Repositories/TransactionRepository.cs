using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreFaces.Transaction.Models;
using CoreFaces.Transaction.Models.Domain;
using CoreFaces.Licensing;

namespace CoreFaces.Transaction.Repositories
{
    public interface ITransactionRepository : IBaseRepository<Models.Domain.Transaction>
    {
        //All rows count.
        int GetRowsCount();
        string GenerateTransactionNumber();
    }

    public class TransactionRepository : Licence, ITransactionRepository
    {
        private readonly TransactionDatabaseContext _transactionDatabaseContext;

        public TransactionRepository(TransactionDatabaseContext transactionDatabaseContext, IOptions<TransactionSettings> productSettings, IHttpContextAccessor iHttpContextAccessor) : base("Transaction", iHttpContextAccessor, productSettings.Value.TransactionLicenseDomain, productSettings.Value.TransactionLicenseKey)
        {
            _transactionDatabaseContext = transactionDatabaseContext;
        }

        public Models.Domain.Transaction GetById(Guid id)
        {
            Models.Domain.Transaction model = _transactionDatabaseContext.Set<Models.Domain.Transaction>().Where(p => p.Id == id).FirstOrDefault();
            return model;
        }

        public Guid Save(Models.Domain.Transaction model)
        {
            model.TransactionNumber = GenerateTransactionNumber();
            _transactionDatabaseContext.Add(model);
            _transactionDatabaseContext.SaveChanges();
            return model.Id;
        }

        public bool Delete(Guid id)
        {
            Models.Domain.Transaction model = this.GetById(id);
            _transactionDatabaseContext.Remove(model);
            int result = _transactionDatabaseContext.SaveChanges();
            return Convert.ToBoolean(result);
        }

        public bool Update(Models.Domain.Transaction model)
        {
            _transactionDatabaseContext.Update(model);
            int result = _transactionDatabaseContext.SaveChanges();
            return Convert.ToBoolean(result);
        }

        public int GetRowsCount()
        {
            return _transactionDatabaseContext.Set<Models.Domain.Transaction>().Count();
        }

        public string GenerateTransactionNumber()
        {
            int rowCount = GetRowsCount() + 1000;
            return (rowCount + 1).ToString();
        }

        public List<Models.Domain.Transaction> GetAll()
        {
            List<Models.Domain.Transaction> model = _transactionDatabaseContext.Set<Models.Domain.Transaction>().ToList();
            return model;
        }

        public decimal TotalAmount(Guid UserId)
        {
            return _transactionDatabaseContext.Set<Models.Domain.Transaction>().Where(p => p.UserId == UserId).Sum(x => x.Amount);
        }

        public List<Models.Domain.Transaction> GetByUserId(Guid userId)
        {
            List<Models.Domain.Transaction> model = _transactionDatabaseContext.Set<Models.Domain.Transaction>().Where(p => p.UserId == userId).ToList();
            return model;
        }
    }

}
