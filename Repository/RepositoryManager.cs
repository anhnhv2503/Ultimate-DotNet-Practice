using Contracts;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICompanyRepository> _companyRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
        }
        public ICompanyRepository Company => _companyRepository.Value;

        public IEmployeeRepository Employee => _employeeRepository.Value;

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
        /*
         EXAMPLE:
        `
        _repository.Company.Create(company); 
        _repository.Company.Create(anotherCompany); 
        _repository.Employee.Update(employee); 
        _repository.Employee.Update(anotherEmployee); 
        _repository.Company.Delete(oldCompany); 
  
        _repository.Save();
        `
        => If there are many classes we can process in this class
         */
    }
}
