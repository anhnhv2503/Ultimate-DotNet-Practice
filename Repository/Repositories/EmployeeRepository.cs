using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Filters;

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

        public async Task<(IEnumerable<Employee> pagedEmployees, int totalCount)> GetEmployees(
            Guid companyId,
            bool trackChanges, 
            int page,
            int size,
            EmployeeFilterParameters  parameters)
        {
            var totalCount = CountByCondition(e => 
                e.CompanyId.Equals(companyId) 
                && (e.Age >= parameters.MinAge && e.Age <= parameters.MaxAge)
                && (e.Name.Contains(parameters.SearchKey))
                );
            var employees =  await FindByCondition(e => 
                    e.CompanyId.Equals(companyId) 
                    && (e.Age >= parameters.MinAge && e.Age <= parameters.MaxAge)
                    && (e.Name.ToLower().Contains(parameters.SearchKey.ToLower())), 
                    trackChanges)
                .OrderBy(e => e.CompanyId)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
            return (employees, totalCount);
        }
    }
}
