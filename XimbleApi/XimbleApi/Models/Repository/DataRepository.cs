using System;
using System.Linq;
using System.Linq.Expressions;
using XimbleApi.Models.Repository.Contracts;

namespace XimbleApi.Models.Repository
{
    public abstract class DataRepository<T> : IDataRepository<T> where T : class
    {
        protected AdventureWorksContext RepositoryContext { get; set; }

        public DataRepository(AdventureWorksContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IQueryable<T>  FindAll()
        {
            return this.RepositoryContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression);
        }
    }
}