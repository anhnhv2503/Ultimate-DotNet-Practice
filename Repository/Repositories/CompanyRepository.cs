using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<(IEnumerable<Company> pagedCompanies, int totalCount)> GetAllCompanies(bool trackChange, int page, int size)
        {
            var totalCount = CountByCondition(c => true);
            var pagedCompanies = await FindAll(trackChange).OrderBy(c => c.Name)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync(); 
            
            return (pagedCompanies, totalCount);
        }

        public async Task<Company> GetCompany(Guid companyId, bool trackChange)
        {
            return await FindByCondition(c => c.Id.Equals(companyId), trackChange).SingleOrDefaultAsync();
        }
    }
}
