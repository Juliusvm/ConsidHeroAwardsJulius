using ConsidTaskJulius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsidTaskJulius.Services
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(Guid id);
        Task<List<T>> List();
        Task<int> Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
