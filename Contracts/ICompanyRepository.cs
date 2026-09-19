using Entities.Models;

namespace Contracts
{
    public interface ICompanyRepository
    {
        Task<(IEnumerable<Company> pagedCompanies, int totalCount)> GetAllCompanies(bool trackChange, int page, int size);
        Task<Company> GetCompany(Guid companyId, bool trackChange);
        void CreateCompany(Company company);
        void DeleteCompany(Company company);

    }
}
