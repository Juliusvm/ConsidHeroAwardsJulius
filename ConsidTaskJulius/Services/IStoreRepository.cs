using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidTaskJulius.Models;

namespace ConsidTaskJulius.Repository
{
    public interface IStoreRepository
    {
        Task<Stores> CreateStore(Stores store);
        Task<Stores> DeleteStore(Stores store);
        Task<Stores> GetStore(Guid storeID);
        Task<List<Stores>> GetStores();
        Task<bool> UpdateStore(Stores store);
    }
}