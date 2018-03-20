using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Web.Data.Entities;
using Customer.Web.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Customer.Web.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerContext _ctx;

        public CustomerRepository(CustomerContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> CreateCustomer(CustomerDto customer)
        {
            _ctx.Add(customer);
            return await SaveAll();
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            return await _ctx.Customers.ToListAsync();
        }

        public async Task<bool> UpdateCustomer(CustomerDto customer)
        {
            _ctx.Update(customer);
            return await SaveAll();
        }

        public async Task<bool> DeleteCustomer(CustomerDto customer)
        {
            _ctx.Remove(customer);
            return await SaveAll();
        }

        public async Task<bool> SaveAll()
        {
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}
