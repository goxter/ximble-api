using System;
using System.Linq;
using System.Linq.Expressions;


namespace XimbleApi.Models.Repository.Contracts
{
    public interface IDataRepository<T>
    {
        IQueryable<T>  FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
