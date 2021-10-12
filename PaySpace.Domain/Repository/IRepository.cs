using PaySpace.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaySpace.Domain.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        public Task<List<T>> GetAll();
        public Task<T> Get(Guid id);
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task<T> Delete(int id);
    }
}
