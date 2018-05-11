using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsidTaskJulius.Models;
using ConsidTaskJulius.Services;
using Microsoft.EntityFrameworkCore;

namespace ConsidTaskJulius.Repository
{
    public class StoreRepository : IStoreRepository
    {
        ConsidTaskContext considContext;

        public StoreRepository(ConsidTaskContext context)
        {
            considContext = context;
   
        }

        public async Task<List<Stores>> List()
        {
            var stores = await considContext.Stores.Include(s => s.Company).ToListAsync();
            return stores;

        }

        public async Task<Stores> GetById(Guid storeID)
        {
            var store = await considContext.Stores.FindAsync(storeID);
            return store;
        }

        public async Task<bool> Update(Stores store)
        {
            considContext.Stores.Update(store);
            await considContext.SaveChangesAsync();
            return true;

        }

        Task<int> IRepository<Stores>.Create(Stores entity)
        {
            considContext.Stores.Add(entity);

            return considContext.SaveChangesAsync(); 
        }

        void IRepository<Stores>.Update(Stores entity)
        {
            considContext.Stores.Update(entity);  
            considContext.SaveChangesAsync(); 
        }

        void IRepository<Stores>.Delete(Stores entity)
        {
            considContext.Stores.Remove(entity);
            considContext.SaveChangesAsync();
          
        }
    }
}
