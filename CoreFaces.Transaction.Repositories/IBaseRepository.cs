using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Transaction.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        Guid Save(TEntity tEntity);
        bool Update(TEntity tEntity);
        bool Delete(Guid Id);
        TEntity GetById(Guid id);
        List<TEntity> GetByUserId(Guid userId);
        List<TEntity> GetAll();
        decimal TotalAmount(Guid UserId);
    }
}
