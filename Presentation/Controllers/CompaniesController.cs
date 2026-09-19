using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dtos;
using UltimateNetFiApi.ActionFilters;

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
        public async Task<IActionResult> GetCompanies(int page, int size)
        {

            var companies = await _serviceManager.CompanyService.GetAllCompanies(true, page, size);

            return Ok(companies);

        }

        [HttpGet("{id:guid}", Name = "CompanyById")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> GetCompanyById(Guid id)
        {
            var company = await _serviceManager.CompanyService.GetCompany(id, false);
            return Ok(company);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyCreationDto dto)
        {
            //if (dto is null)
            //{
            //    return BadRequest("CompanyCreationDto object is null");
            //}
            var createdCompany = await _serviceManager.CompanyService.CreateCompany(dto);

            return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
        }
    }
}
