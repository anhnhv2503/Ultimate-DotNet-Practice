using Contracts;
using Entities.Models;
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

        public IEnumerable<Company> GetAllCompanies(bool trackChange)
        {
            return FindAll(trackChange).OrderBy(c => c.Name).ToList();
        }

        public Company GetCompany(Guid companyId, bool trackChange)
        {
            return FindByCondition(c => c.Id.Equals(companyId), trackChange).SingleOrDefault();
        }
    }
}
