using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Transaction.Services
{
    public interface IBaseService<TEntity>
    {
        Guid Save(TEntity tEntity);
        bool Update(TEntity tEntity);
        bool Delete(Guid Id);
        TEntity GetById(Guid id);
        List<Models.Domain.Transaction> GetByUserId(Guid userId);
        List<TEntity> GetAll();
        decimal TotalAmount(Guid UserId);
    }
}
