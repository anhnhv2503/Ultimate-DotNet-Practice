using Shared.Dto;
using Shared.Dtos;
using Shared.Paging;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        Task<MetaData<IEnumerable<CompanyDto>>> GetAllCompanies(bool trackChanges, int page, int size);
        Task<CompanyDto> GetCompany(Guid id, bool trackChanges);

        Task<CompanyDto> CreateCompany(CompanyCreationDto company);
    }
}
