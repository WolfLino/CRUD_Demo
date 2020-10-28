using CRUD.API.DTOs;
using CRUD.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerApiService customerService;

        public CustomerController(ICustomerApiService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("{customerId}", Name = "GetCustomer")]
        public async Task<IActionResult> GetWalletAsync(int customerId)
        {
            var customer = await customerService.GetCustomerById(customerId);

            if (customer == null)
                return NotFound(new { StatusCode = 404, Message = "Cliente não encontrado." });

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> PostWalletAsync(CustomerToCreateDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = await customerService.CreateCustomer(customerDto);
            return CreatedAtRoute("GetCustomer", new { customerId = customer.Id }, customer);
        }
    }
}
