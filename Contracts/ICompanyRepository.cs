using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompanies(bool trackChange);
        Task<Company> GetCompany(Guid companyId, bool trackChange);
        void CreateCompany(Company company);
        void DeleteCompany(Company company);

    }
}
