using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompanies(bool trackChange);
        Company GetCompany(Guid companyId, bool trackChange);
        void CreateCompany(Company company);
        void DeleteCompany(Company company);

    }
}
