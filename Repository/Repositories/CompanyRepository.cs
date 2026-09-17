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
