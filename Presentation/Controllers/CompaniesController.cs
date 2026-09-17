using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dto;
using Shared.Dtos;
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

        [HttpGet("{id:guid}", Name = "CompanyById")]
        public IActionResult GetCompanyById(Guid id)
        {
            var company = _serviceManager.CompanyService.GetCompany(id, false);
            return Ok(company);
        }

        [HttpPost]
        public IActionResult CreateCompany([FromBody] CompanyCreationDto dto)
        {
            if(dto is null)
            {
                return BadRequest("CompanyCreationDto object is null");
            }
            var createdCompany = _serviceManager.CompanyService.CreateCompany(dto);

            return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
        }
    }
}
