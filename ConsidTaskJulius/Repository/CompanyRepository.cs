using ConsidTaskJulius.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsidTaskJulius.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        ConsidTaskContext db;

     
        public CompanyRepository(ConsidTaskContext DB)
        {
            db = DB;
        }
   
        public Task<Companies> GetById(Guid id)
        {
            return db.Companies.FindAsync(id); ;
        }

        public Task<List<Companies>> List()
        {
            return db.Companies.Include(c => c.Stores).ToListAsync();
        }

        public Task<int> Create(Companies entity)
        {
            db.Companies.Add(entity);
            return db.SaveChangesAsync();
         
        }

        public void Update(Companies entity)
        {

            db.Companies.Update(entity);
            db.SaveChangesAsync();
            
        }

        public void Delete(Companies entity)
        {
            var companyStores = (from store in db.Stores
                                 where store.CompanyId == entity.Id
                                 select store).ToList();


            db.Stores.RemoveRange(companyStores);
            db.Companies.Remove(entity);

            db.SaveChangesAsync();
           
        }
    }
}
