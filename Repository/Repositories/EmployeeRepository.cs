using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Shared.Paging;

namespace Repository.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEmployee(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public async Task<Employee> GetEmployee(Guid companyId, Guid employeeId, bool trackChanges)
        {
            return await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(employeeId), trackChanges)
                .OrderBy(e => e.CompanyId)
                .FirstOrDefaultAsync();
        }

        public async Task<MetaData<IEnumerable<Employee>>> GetEmployees(Guid companyId, bool trackChanges, int page,
            int size)
        {
            var totalCount = CountByCondition(e => e.CompanyId.Equals(companyId));
            var totalPages = (int) Math.Ceiling((double) totalCount / size);
            var employees =  await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
                .OrderBy(e => e.CompanyId)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
            return new MetaData<IEnumerable<Employee>>()
            {
                Data = employees,
                TotalCount = totalCount,
                CurrentPage = page,
                TotalPages = totalPages
            };
        }
    }
}
