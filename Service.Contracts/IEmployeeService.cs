using System.Dynamic;
using Shared.Dto;
using Shared.Dtos;
using Shared.Filters;
using Shared.Paging;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        Task<MetaData<IEnumerable<EmployeeDto>>> GetEmployees(
            Guid companyId, 
            bool trackChanges, 
            int page, int size, 
            EmployeeFilterParameters parameters
            );
        Task<EmployeeDto> GetEmployee(Guid companyId, Guid employeeId, bool trackChanges);
        Task<EmployeeDto> CreateEmployee(Guid companyId, EmployeeCreationDto employee, bool trackChanges);
        Task CreateEmployees(Guid companyId, IEnumerable<EmployeeCreationDto> employeeDtos, bool trackChanges);
    }
}
