using Shared.Dto;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges);
        EmployeeDto GetEmployee(Guid companyId, Guid employeeId, bool trackChanges);
        EmployeeDto CreateEmployee(Guid companyId, EmployeeCreationDto employee, bool trackChanges);
    }
}
