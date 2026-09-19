using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.Dto;
using Shared.Dtos;
using Shared.Paging;

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

        public async Task<MetaData<IEnumerable<CompanyDto>>> GetAllCompanies(bool trackChanges, int page, int size)
        {
                var pagedCompanies = await _repository.Company.GetAllCompanies(trackChanges, page, size);
                var totalCount = pagedCompanies.totalCount;
                var totalPages = (int) Math.Ceiling((double) totalCount / size);
                var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(pagedCompanies.pagedCompanies);
                return new MetaData<IEnumerable<CompanyDto>>()
                {
                    Data = companiesDto,
                    TotalCount = totalCount,
                    CurrentPage = page,
                    TotalPages = totalPages
                };

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
