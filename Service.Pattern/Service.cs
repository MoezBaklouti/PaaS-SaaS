using Solution.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Pattern
{
    public class Service<T> : IService<T> where T : class
    {
        IUnitOfWork utk;
        public Service(IUnitOfWork utk)
        {
            this.utk = utk;
                
        }
        public void Add(T entity)
        {
            utk.GetRepositoryBase<T>().Add(entity);
        }

        public void Commit()
        {
            utk.commit();
        }

        public void Delete(Expression<Func<T, bool>> Condition)
        {
            utk.GetRepositoryBase<T>().Delete(Condition);
        }

        public void Delete(T entity)
        {
            utk.GetRepositoryBase<T>().Delete(entity);
        }

        public void Dispose()
        {
            utk.Dispose();
        }

        public T Get(Expression<Func<T, bool>> Condition)
        {
            return utk.GetRepositoryBase<T>().Get(Condition);
        }

        public T GetById(string id)
        {
            return utk.GetRepositoryBase<T>().GetById(id);
        }

        public T GetById(int id)
        {
            return utk.GetRepositoryBase<T>().GetById(id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> Condition = null, Expression<Func<T, bool>> OrderBy = null)
        {
            return utk.GetRepositoryBase<T>().GetMany(Condition,OrderBy);
        }

        public void Update(T entity)
        {
            utk.GetRepositoryBase<T>().Update(entity);
        }
    }
}
