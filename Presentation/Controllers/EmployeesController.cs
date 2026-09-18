using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

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
        public IActionResult GetEmployees(Guid companyId)
        {
            return Ok(_service.EmployeeService.GetEmployees(companyId, false));
        }

        [HttpGet("{employeeId}", Name = "EmployeeById")]
        public IActionResult GetEmployeeById(Guid companyId, Guid employeeId)
        {
            var reponse = _service.EmployeeService.GetEmployee(companyId, employeeId, false);

            return Ok(reponse);
        }

        [HttpPost]
        public IActionResult CreateEmployee(Guid companyId, [FromBody] EmployeeCreationDto dto)
        {
            if(dto is null)
                return BadRequest("EmployeeCreationDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            
            var response = _service.EmployeeService.CreateEmployee(companyId, dto, false);
            return CreatedAtRoute("EmployeeById", new { companyId, employeeId = response.Id }, response);
        }
    }
}
