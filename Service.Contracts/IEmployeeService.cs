using Shared.Dto;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployees(Guid companyId, bool trackChanges);
        Task<EmployeeDto> GetEmployee(Guid companyId, Guid employeeId, bool trackChanges);
        Task<EmployeeDto> CreateEmployee(Guid companyId, EmployeeCreationDto employee, bool trackChanges);
        Task CreateEmpoyees(Guid companyId, IEnumerable<EmployeeCreationDto> employeeDtos, bool trackChanges);
    }
}
