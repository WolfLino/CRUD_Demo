using CRUD.Application.Interfaces;
using CRUD.Application.Mapper;
using CRUD.Application.Models;
using CRUD.Core.Entities;
using CRUD.Core.Repositories;
using System;
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

        public async Task<CustomerModel> Create(CustomerModel customerModel)
        {
            await ValidateWalletIfExist(customerModel);

            var mappedEntity = ObjectMapper.Mapper.Map<Customer>(customerModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entidade não foi mapeada");

            var newEntity = await customerRepository.AddAsync(mappedEntity);

            var returnMappedEntity = ObjectMapper.Mapper.Map<CustomerModel>(newEntity);

            return returnMappedEntity;
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

        private async Task ValidateWalletIfExist(CustomerModel customerModel)
        {
            var existingEntity = await customerRepository.GetByIdAsync(customerModel.Id);
            if (existingEntity != null)
                throw new ApplicationException($"{customerModel} com este ID já existe");
        }
    }
}
