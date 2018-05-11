using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidTaskJulius.Models;

namespace ConsidTaskJulius.Repository
{
    public interface ICompanyRepository
    {
        Task<Companies> CreateCompany(Companies company);
        Task<Companies> DeleteCompany(Companies company);
        Task<List<Companies>> GetCompanies();
        Task<Companies> GetCompany(Guid companyID);
        Task<bool> UpdateCompany(Companies company);
    }
}