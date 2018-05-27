using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using CoreFaces.Transaction.Models;
using CoreFaces.Licensing;

namespace CoreFaces.Transaction.Repositories
{
    public interface ITransactionSchemaRepository
    {
        bool DropTables();
        bool EnsureCreated();
    }

    public class TransactionSchemaRepository : Licence, ITransactionSchemaRepository
    {
        private readonly TransactionDatabaseContext _transactionDatabaseContext;

        public TransactionSchemaRepository(TransactionDatabaseContext transactionDatabaseContext, IOptions<TransactionSettings> productSettings, IHttpContextAccessor iHttpContextAccessor) : base("Transaction", iHttpContextAccessor, productSettings.Value.TransactionLicenseDomain, productSettings.Value.TransactionLicenseKey)
        {
            _transactionDatabaseContext = transactionDatabaseContext;
        }

        public bool DropTables()
        {
            int result = _transactionDatabaseContext.Database.ExecuteSqlCommand("DROP TABLE Transaction;");
            if (result == 0)
                return true;
            else
                return false;
        }

        public bool EnsureCreated()
        {
            RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)_transactionDatabaseContext.Database.GetService<IDatabaseCreator>();
            databaseCreator.CreateTables();
            return true;
        }
    }

}
