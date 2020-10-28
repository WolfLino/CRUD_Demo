using AutoMapper;
using CRUD.API.DTOs;
using CRUD.API.Interfaces;
using CRUD.Application.Interfaces;
using CRUD.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.API.Services
{
    public class CustomerApiService : ICustomerApiService
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public CustomerApiService(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }

        public async Task<CustomerDto> CreateCustomer(CustomerToCreateDto customerDto)
        {
            var mappedCustomer = mapper.Map<CustomerModel>(customerDto);
            if (mappedCustomer == null)
                throw new Exception($"Entidade não pode ser mapeada.");

            var customer = await customerService.Create(mappedCustomer);

            var returnedCustomer = mapper.Map<CustomerDto>(customer);

            return returnedCustomer;
        }

        public Task DeleteCustomer(CustomerDto customerDto)
        {
            throw new System.NotImplementedException();
        }

        public async Task<CustomerDto> GetCustomerById(int customerId)
        {
            var customer = await customerService.GetCustomerById(customerId);
            var mapped = mapper.Map<CustomerDto>(customer);
            return mapped;
        }

        public Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateCustomer(CustomerDto customerDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
