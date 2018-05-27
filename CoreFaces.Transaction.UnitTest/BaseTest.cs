using CoreFaces.Transaction.Models;
using CoreFaces.Transaction.Repositories;
using CoreFaces.Transaction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Transaction.UnitTest
{

    public class BaseTest
    {
        public TransactionDatabaseContext _transactionServiceDatabaseContext;
        public readonly ITransactionService _transactionServiceService;


        public readonly ITransactionSchemaService transactionSchemaService;
        public readonly IOptions<TransactionSettings> _transactionSettings;
        public readonly IHttpContextAccessor iHttpContextAccessor;
        public BaseTest()
        {

            DbContextOptionsBuilder<TransactionDatabaseContext> builderTransaction = new DbContextOptionsBuilder<TransactionDatabaseContext>();
            var connectionString = "server=localhost;userid=root;password=123456;database=Product;";
            builderTransaction.UseMySql(connectionString);
            //.UseInternalServiceProvider(serviceProvider); //burası postgress ile sıkıntı çıkartmıyor, fakat mysql'de çalışmıyor test esnasında hata veriyor.

            _transactionServiceDatabaseContext = new TransactionDatabaseContext(builderTransaction.Options);
            //_context.Database.Migrate();

            //Configuration
            iHttpContextAccessor = new HttpContextAccessor { HttpContext = new DefaultHttpContext() };
            _transactionSettings = Options.Create(new TransactionSettings()
            {
                FileUploadFolderPath = @"C:\Users\haltunbas\Documents\GitHub\ProductV2\Product.Api\Product.Api\wwwroot\upload\"
            });

            _transactionServiceService = new TransactionService(_transactionServiceDatabaseContext, _transactionSettings, iHttpContextAccessor);
            transactionSchemaService = new TransactionSchemaService(_transactionServiceDatabaseContext, _transactionSettings, iHttpContextAccessor);


        }
    }

}
