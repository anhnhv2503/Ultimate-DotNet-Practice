using System.Dynamic;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.Dto;
using Shared.Dtos;
using Shared.Filters;
using Shared.Paging;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository, ILoggerManager logger, 
            IMapper mapper) 
        { 
            _repository = repository; 
            _logger = logger; 
            _mapper = mapper; 
        } 

        private async Task CheckCompanyExists(Guid companyId, bool trackChanges)
        {
            var company = await _repository.Company.GetCompany(companyId, trackChanges);
            if (company is null) throw new NotFoundException($"Not found Company with id: {companyId}");

        }

        public async Task<EmployeeDto> CreateEmployee(Guid companyId, EmployeeCreationDto employee, bool trackChanges)
        {
            await CheckCompanyExists(companyId, trackChanges);
            var employeeEntity = _mapper.Map<Employee>(employee);
            _repository.Employee.CreateEmployee(companyId, employeeEntity);
            await _repository.SaveAsync();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);
            return employeeToReturn;
        }

        public async Task CreateEmployees(Guid companyId, IEnumerable<EmployeeCreationDto> employeeDtos, bool trackChanges)
        {
            await CheckCompanyExists(companyId, trackChanges);
            foreach(var dto in employeeDtos)
            {
                var employeeEntity = _mapper.Map<Employee>(dto);
                _repository.Employee.CreateEmployee(companyId, employeeEntity);
                await _repository.SaveAsync();
            }
        }

        public async Task<EmployeeDto> GetEmployee(Guid companyId, Guid employeeId, bool trackChanges)
        {
            await CheckCompanyExists(companyId, trackChanges);
            var employee = await _repository.Employee.GetEmployee(companyId, employeeId, trackChanges);
            if (employee is null) throw new NotFoundException($"Not found Employee with id: {employeeId}");
            
            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto; 
        }

        public async Task<MetaData<IEnumerable<EmployeeDto>>> GetEmployees(
            Guid companyId,
            bool trackChanges,
            int page, int size,
            EmployeeFilterParameters parameters
            )
        {
            await CheckCompanyExists(companyId, trackChanges);
            if(!parameters.ValidAgeRange) throw new BadRequestException("Invalid age range");
            
            var metaDataEmployees = await _repository.Employee.GetEmployees(companyId, trackChanges, page, size, parameters);
            
            var pagedEmployees = metaDataEmployees.pagedEmployees;
            var totalCount = metaDataEmployees.totalCount;
            var totalPages = (int) Math.Ceiling((double) totalCount / size);

            var employeeDto = _mapper.Map<IEnumerable<EmployeeDto>>(pagedEmployees);
           
            return new MetaData<IEnumerable<EmployeeDto>>()
            {
                Data = employeeDto,
                TotalCount = totalCount,
                CurrentPage = page,
                TotalPages = totalPages
            };

        }
    }
}
