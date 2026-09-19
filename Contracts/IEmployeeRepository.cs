using Entities.Models;
using Shared.Filters;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        Task<(IEnumerable<Employee> pagedEmployees, int totalCount)> GetEmployees(Guid companyId, bool trackChanges, int page, int size,EmployeeFilterParameters parameters);
        Task<Employee> GetEmployee(Guid companyId, Guid employeeId, bool trackChanges);
        void CreateEmployee(Guid companyId, Employee employee);
    }
}
