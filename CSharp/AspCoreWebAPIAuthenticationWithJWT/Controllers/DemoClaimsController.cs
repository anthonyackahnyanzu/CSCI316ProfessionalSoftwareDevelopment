using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreWebAPIAuthenticationWithJWT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemoClaimsController : ControllerBase
    {
        // GET: api/democlaims/read
        [HttpGet("read")]
        [Authorize(Policy = "CanRead")]
        public IActionResult ReadData()
        {
            return Ok("You have CanRead access!");
        }

        // POST: api/democlaims/edit
        [HttpPost("edit")]
        [Authorize(Policy = "CanEdit")]
        public IActionResult EditData()
        {
            return Ok("You have CanEdit access!");
        }

        // DELETE: api/democlaims/fullaccess
        [HttpDelete("fullaccess")]
        [Authorize(Policy = "FullAccess")]
        public IActionResult FullAccessData()
        {
            return Ok("You have FullAccess!");
        }
    }
}
