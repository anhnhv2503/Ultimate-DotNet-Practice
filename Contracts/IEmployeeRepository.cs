using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Shared.Paging;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        Task<MetaData<IEnumerable<Employee>>> GetEmployees(Guid companyId, bool trackChanges, int page, int size);
        Task<Employee> GetEmployee(Guid companyId, Guid employeeId, bool trackChanges);
        void CreateEmployee(Guid companyId, Employee employee);
    }
}
