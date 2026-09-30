using Entities.Error;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dtos;
using UltimateNetFiApi.ActionFilters;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController(IServiceManager service) => _service = service;

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistrationDto)
        {
            var result = await _service.AuthenticationService.RegisterUser(userRegistrationDto);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201, new {data = result});

        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] AuthentiationRequest authRequest)
        {
            if (!await _service.AuthenticationService.ValidateUser(authRequest))
                return Unauthorized(new ErrorDetails
                {
                    StatusCode = (int) StatusCodes.Status401Unauthorized,
                    Message = "Invalid Username or Password"
                });

            var tokenDto = await _service.AuthenticationService
                .CreateToken(true);

            return Ok(tokenDto);
        }

        [HttpGet("profile")]
        [Authorize]
        public IActionResult GetAuthenticatedProfile()
        {
            return Ok(_service.AuthenticationService.GetAuthenticatedUser());
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken(TokenDto tokenDto)
        {
            var tokenDtoReturn = await _service.AuthenticationService.RefreshToken(tokenDto);

            return Ok(tokenDtoReturn);
        }

    }
}
