using CRUD.Application.DTOs;
using CRUD.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerApiService customerApiService;

        public CustomerController(ICustomerApiService customerApiService)
        {
            this.customerApiService = customerApiService ?? throw new ArgumentNullException(nameof(customerApiService));
        }

        [HttpGet("{customerId}", Name = "GetCustomer")]
        public async Task<IActionResult> GetWalletAsync(int customerId)
        {
            var customer = await customerApiService.GetCustomerById(customerId);

            if (customer == null)
                return NotFound(new { StatusCode = 404, Message = "Cliente não encontrado." });

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> PostWalletAsync(CustomerToCreateDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = await customerApiService.CreateCustomer(customerDto);
            return CreatedAtRoute("GetCustomer", new { customerId = customer.Id }, customer);
        }

        [HttpGet("cep/{cep}")]
        public async Task<IActionResult> GetCep(string cep)
        {
            if (cep.Length != 8)
                return BadRequest(new { Status = "400", Message = "O CEP deve conter 8 digitos." });

            var address = await customerApiService.GetAddressByCep(cep);

            if (address == null)
                return NotFound(new { Status = "404", Message = "Endereço não encontrado." });

            return Ok(address);
        }
    }
}
