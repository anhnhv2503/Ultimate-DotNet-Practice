using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CompaniesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {

            var companies = _serviceManager.CompanyService.GetAllCompanies(true);

            return Ok(companies);

        }

        [HttpGet("{id:guid}")]
        public IActionResult GetCompanyById(Guid id)
        {
            var company = _serviceManager.CompanyService.GetCompany(id, false);
            return Ok(company);
        }
    }
}
