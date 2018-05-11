using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsidTaskJulius.Models;
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
        public async Task<Stores> CreateStore(Stores store)
        {
            considContext.Stores.Add(store);
            await considContext.SaveChangesAsync();
            return store;
        }

        public async Task<List<Stores>> GetStores()
        {
            var stores = await considContext.Stores.Include(s => s.Company).ToListAsync();
            return stores;

        }

        public async Task<Stores> DeleteStore(Stores store)
        {
            considContext.Stores.Remove(store);
            await considContext.SaveChangesAsync();
            return store;
        }

        public async Task<Stores> GetStore(Guid storeID)
        {
            var store = await considContext.Stores.FindAsync(storeID);
            return store;
        }

        public async Task<bool> UpdateStore(Stores store)
        {
            considContext.Stores.Update(store);
            await considContext.SaveChangesAsync();
            return true;

        }
    }
}
