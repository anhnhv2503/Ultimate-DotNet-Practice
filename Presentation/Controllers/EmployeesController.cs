using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using UltimateNetFiApi.ActionFilters;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/companies/{companyId}/employees")]
    public class EmployeesController : ControllerBase
    {

        private readonly IServiceManager _service;

        public EmployeesController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees(Guid companyId, int page, int size)
        {
            return Ok(await _service.EmployeeService.GetEmployees(companyId, false, page, size));
        }

        [HttpGet("{employeeId}", Name = "EmployeeById")]
        public async Task<IActionResult> GetEmployeeById(Guid companyId, Guid employeeId)
        {
            var reponse = await _service.EmployeeService.GetEmployee(companyId, employeeId, false);

            return Ok(reponse);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateEmployee(Guid companyId, [FromBody] EmployeeCreationDto dto)
        {
            //if(dto is null)
            //    return BadRequest("EmployeeCreationDto object is null");
            //if (!ModelState.IsValid)
            //    return UnprocessableEntity(ModelState);
            
            var response = await _service.EmployeeService.CreateEmployee(companyId, dto, false);
            return CreatedAtRoute("EmployeeById", new { companyId, employeeId = response.Id }, response);
        }

        [HttpPost("multi")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateEmployees(Guid companyId, [FromBody] IEnumerable<EmployeeCreationDto> employeeDtos)
        {
            await _service.EmployeeService.CreateEmpoyees(companyId, employeeDtos, false);
            return Ok(new
            {
                message = $"{employeeDtos.Count()} employee(s) created"
            });
        }
    }
}
