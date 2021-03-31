using System;
using System.Net;
using System.Threading.Tasks;
using Customer.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Customer.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [ProducesResponseType(typeof(Entities.Customer), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Customer>> GetCustomers()
        {
            var customer = await _repository.GetCustomers();
            return Ok(customer);
        }

        [HttpGet("{Mail}", Name = "GetCustomer")]
        [ProducesResponseType(typeof(Entities.Customer), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Customer>> GetDiscount(string mail)
        {
            var discount = await _repository.GetCustomerByMail(mail);
            return Ok(discount);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Entities.Customer), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Customer>> CreateCustomer([FromBody] Entities.Customer customer)
        {
            await _repository.CreateCustomer(customer);
            return CreatedAtRoute("GetCustomerByMail", new { mail = customer.Mail }, customer);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Entities.Customer), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Customer>> UpdateBasket([FromBody] Entities.Customer customer)
        {
            return Ok(await _repository.UpdateCustomer(customer));
        }

        [HttpDelete("{id}", Name = "DeleteCustomer")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteCustomer(int id)
        {
            return Ok(await _repository.DeleteCustomer(id));
        }
    }
}
