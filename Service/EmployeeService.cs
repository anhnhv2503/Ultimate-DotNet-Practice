using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.Dto;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public EmployeeDto CreateEmployee(Guid companyId, EmployeeCreationDto employee, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges);
            if (company is null) throw new NotFoundException($"Not found Company with id: {companyId}");
           
            var employeeEntity = _mapper.Map<Employee>(employee);
            _repository.Employee.CreateEmployee(companyId, employeeEntity);
            _repository.Save();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);
            return employeeToReturn;
        }

        public EmployeeDto GetEmployee(Guid companyId, Guid employeeId, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges);
            if (company is null) throw new NotFoundException($"Not found Company with id: {companyId}");

            var employee = _repository.Employee.GetEmployee(companyId, employeeId, trackChanges);
            if (employee is null) throw new NotFoundException($"Not found Employee with id: {employeeId}");
            
            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto; 
        }

        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges);
            if (company is null) throw new NotFoundException($"Not found company with id: {companyId}");

            var employees = _repository.Employee.GetEmployees(companyId, trackChanges);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return employeesDto;
        }
    }
}
