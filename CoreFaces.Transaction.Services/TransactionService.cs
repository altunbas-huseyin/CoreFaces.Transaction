using CoreFaces.Transaction.Models;
using CoreFaces.Transaction.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Transaction.Services
{

    public interface ITransactionService : IBaseService<Models.Domain.Transaction>
    {
        int GetRowsCount();
    }
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly TransactionDatabaseContext _transactionDatabaseContext;
        public TransactionService(TransactionDatabaseContext transactionDatabaseContext, IOptions<TransactionSettings> transactionSettings, IHttpContextAccessor iHttpContextAccessor)
        {
            _transactionDatabaseContext = transactionDatabaseContext;
            _transactionRepository = new TransactionRepository(transactionDatabaseContext, transactionSettings, iHttpContextAccessor);
        }

        public Models.Domain.Transaction GetById(Guid id)
        {
            return _transactionRepository.GetById(id);
        }

        public bool Delete(Guid id)
        {
            return _transactionRepository.Delete(id);
        }

        public bool Update(Models.Domain.Transaction model)
        {
            return _transactionRepository.Update(model);
        }

        public Models.Domain.Transaction GetProductId(Guid Id, Guid apiUserId)
        {
            Models.Domain.Transaction model = _transactionRepository.GetById(Id);
            return model;
        }

        public Guid Save(Models.Domain.Transaction model)
        {
            _transactionRepository.Save(model);
            return model.Id;
        }

        public int GetRowsCount()
        {
            return _transactionRepository.GetRowsCount();
        }

        public List<Models.Domain.Transaction> GetAll()
        {
            return _transactionRepository.GetAll();
        }

        public decimal TotalAmount(Guid UserId)
        {
            return _transactionRepository.TotalAmount(UserId);
        }

        public List<Models.Domain.Transaction> GetByUserId(Guid userId)
        {
            return _transactionRepository.GetByUserId(userId);
        }

        public string GenerateOrderNumber()
        {
            int rowCount = GetRowsCount() + 1000;
            return (rowCount + 1).ToString();
        }
    }

}
