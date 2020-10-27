using CRUD.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> GetCustomerList();
        Task<CustomerModel> GetCustomerById(int customerId);
        Task<CustomerModel> Create(CustomerModel customerModel);
        Task Update(CustomerModel customerModel);
        Task Delete(CustomerModel customerModel);
    }
}
