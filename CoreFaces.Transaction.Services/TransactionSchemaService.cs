using CoreFaces.Transaction.Models;
using CoreFaces.Transaction.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Transaction.Services
{
    public interface ITransactionSchemaService
    {
        bool DropTables();
        bool EnsureCreated();
    }

    public class TransactionSchemaService : ITransactionSchemaService
    {
        private readonly TransactionDatabaseContext _transactionDatabaseContext;
        private readonly ITransactionSchemaRepository _transactionSchemaRepository;
        public TransactionSchemaService(TransactionDatabaseContext transactionDatabaseContext, IOptions<TransactionSettings> transactionSettings, IHttpContextAccessor iHttpContextAccessor)
        {
            _transactionDatabaseContext = transactionDatabaseContext;
            _transactionSchemaRepository = new TransactionSchemaRepository(_transactionDatabaseContext, transactionSettings, iHttpContextAccessor);
        }

        public bool DropTables()
        {
            return _transactionSchemaRepository.DropTables();
        }

        public bool EnsureCreated()
        {
            return _transactionSchemaRepository.EnsureCreated();
        }
    }

}
