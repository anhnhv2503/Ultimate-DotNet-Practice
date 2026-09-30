using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/check")]
    public class HealthCheckContoller : ControllerBase
    {

        [HttpGet]
        public IActionResult HealthCheck()
        {
            return Ok(new
            {
                message = "Server is ok...."
            });
        }

        [HttpGet("manager/auth")]
        [Authorize(Roles = "Manager")]
        public IActionResult ManagerAuthorized() {

            return Ok(new
            {
                message = "Manager Authorized",
                role = "Manager"
            });
        }

        [HttpGet("admin/auth")]
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminAuthorized()
        {

            return Ok(new
            {
                message = "Admin Authorized",
                role = "Admin"
            });
        }

    }
}
