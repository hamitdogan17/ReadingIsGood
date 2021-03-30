using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Customer.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new List<string> {
            "Hasan", "Serdar", "Tahir", "Necati", "Salih", "Ruhi", "Muiddin"
         });
        }
    }
}
