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
        public async Task<Companies> CreateCompany(Companies company)
        {
            db.Companies.Add(company);
            await db.SaveChangesAsync();
            return company;
        }

        public async Task<List<Companies>> GetCompanies()
        {
            var companies = await db.Companies.Include(c => c.Stores).ToListAsync();
         
            return companies;

        }

        public async Task<Companies> DeleteCompany(Companies company)
        {

            var companyStores = (from store in db.Stores
                     where store.CompanyId == company.Id
                     select store).ToList();


            db.Stores.RemoveRange(companyStores);
            db.Companies.Remove(company);
   
            await db.SaveChangesAsync();
            return company;
        }

        public async Task<Companies> GetCompany(Guid companyID)
        {
            var company = await db.Companies.FindAsync(companyID);
            return company;
        }

        public async Task<bool> UpdateCompany(Companies company)
        {

            db.Companies.Update(company);
            await db.SaveChangesAsync();
            return true;

        }

    }
}
