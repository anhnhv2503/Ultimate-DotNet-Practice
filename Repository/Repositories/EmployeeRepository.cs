using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public Employee GetEmployee(Guid companyId, Guid employeeId, bool trackChanges)
        {
            return FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(employeeId), trackChanges).OrderBy(e => e.CompanyId).FirstOrDefault();
        }

        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges)
        {
            return FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges).OrderBy(e => e.CompanyId).ToList();
        }
    }
}
