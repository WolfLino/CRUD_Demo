using CRUD.Core.Entities;
using CRUD.Core.Repositories;
using CRUD.Infrastructure.Data;
using CRUD.Infrastructure.Repository.Base;

namespace CRUD.Infrastructure.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CrudContext dbContext) : base(dbContext) { }
    }
}
