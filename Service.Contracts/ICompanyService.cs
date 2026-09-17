using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
        CompanyDto GetCompany(Guid id, bool trackChanges);
    }
}
