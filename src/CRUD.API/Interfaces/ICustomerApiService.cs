using CRUD.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.API.Interfaces
{
    public interface ICustomerApiService
    {
        Task<CustomerDto> GetCustomerById(int customerId);
        Task<IEnumerable<CustomerDto>> GetCustomers();
        Task<CustomerDto> CreateCustomer(CustomerDto customerDto);
        Task UpdateCustomer(CustomerDto customerDto);
        Task DeleteCustomer(CustomerDto customerDto);
    }
}
