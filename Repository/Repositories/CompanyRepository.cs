using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCompany(Company company)
        {
            Create(company);
        }

        public void DeleteCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Company>> GetAllCompanies(bool trackChange)
        {
            return await FindAll(trackChange).OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Company> GetCompany(Guid companyId, bool trackChange)
        {
            return await FindByCondition(c => c.Id.Equals(companyId), trackChange).SingleOrDefaultAsync();
        }
    }
}
