using Shared.Dto;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Shared.Paging;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        Task<MetaData<IEnumerable<EmployeeDto>>> GetEmployees(Guid companyId, bool trackChanges, int page, int size);
        Task<EmployeeDto> GetEmployee(Guid companyId, Guid employeeId, bool trackChanges);
        Task<EmployeeDto> CreateEmployee(Guid companyId, EmployeeCreationDto employee, bool trackChanges);
        Task CreateEmployees(Guid companyId, IEnumerable<EmployeeCreationDto> employeeDtos, bool trackChanges);
    }
}
