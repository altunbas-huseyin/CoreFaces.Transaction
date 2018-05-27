using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Transaction.Models.Mapping
{
    public class TransactionMap
    {
        public TransactionMap(EntityTypeBuilder<Domain.Transaction> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.UserId).IsRequired();
            entityBuilder.Property(t => t.AreaId);
            entityBuilder.Property(t => t.OrderId).IsRequired();
            entityBuilder.Property(t => t.Currency).IsRequired();
            entityBuilder.Property(t => t.TransactionType).IsRequired();
            entityBuilder.Property(t => t.Amount).IsRequired();
            entityBuilder.Property(t => t.TransactionNumber).IsRequired();
            entityBuilder.Property(t => t.Title);
            entityBuilder.Property(t => t.Description);
            entityBuilder.Property(t => t.CreateDate).IsRequired();
            entityBuilder.Property(t => t.UpdateDate).IsRequired();

            entityBuilder.HasIndex(t => new { t.TransactionNumber }).IsUnique();
        }
    }
}
