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
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        
        public CompanyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CompanyDto> CreateCompany(CompanyCreationDto company)
        {
            var companyEntity = _mapper.Map<Company>(company);
            _repository.Company.CreateCompany(companyEntity);
            await _repository.SaveAsync();

            var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);
            return companyToReturn;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompanies(bool trackChanges)
        {
                var companies = await _repository.Company.GetAllCompanies(trackChanges);
                var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
                return companiesDto;
           
        }

        public async Task<CompanyDto> GetCompany(Guid id, bool trackChanges)
        {
            var company = await _repository.Company.GetCompany(id, trackChanges);

            if (company is null)
                throw new NotFoundException($"Not found company with id: {id}");


            var companyDto = _mapper.Map<CompanyDto>(company);

            return companyDto;
        }
    }
}
