﻿using CRUD.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.API.Interfaces
{
    public interface ICustomerApiService
    {
        Task<CustomerDto> GetCustomerById(int customerId);
        Task<IEnumerable<CustomerDto>> GetCustomers();
        Task<CustomerDto> CreateCustomer(CustomerToCreateDto customerDto);
        Task UpdateCustomer(CustomerDto customerDto);
        Task DeleteCustomer(CustomerDto customerDto);
        Task<AddressDto> GetAddressByCep(string cep);
    }
}
