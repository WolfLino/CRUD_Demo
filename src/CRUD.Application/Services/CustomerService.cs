using CRUD.Application.Interfaces;
using CRUD.Application.Mapper;
using CRUD.Application.Models;
using CRUD.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Task<CustomerModel> Create(CustomerModel customerModel)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(CustomerModel customerModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<CustomerModel> GetCustomerById(int customerId)
        {
            var customer = await customerRepository.GetByIdAsync(customerId);
            var mapped = ObjectMapper.Mapper.Map<CustomerModel>(customer);
            return mapped;
        }

        public Task<IEnumerable<CustomerModel>> GetCustomerList()
        {
            throw new System.NotImplementedException();
        }

        public Task Update(CustomerModel customerModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
