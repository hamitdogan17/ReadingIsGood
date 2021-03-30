using Auth.API.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Auth.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Login(string userName, string password)
        {
            TokenHandler._configuration = _configuration;
            return Ok(userName == "hamit" && password == "12345" ? TokenHandler.CreateAccessToken() : new UnauthorizedResult());
        }
    }
}
