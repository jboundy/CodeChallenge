using System;
using System.Collections.Generic;
using System.Linq;
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
            await _ctx.AddAsync(customer);
            return await SaveAllAsync();
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            return await _ctx.Customers.ToListAsync();
        }

        public async Task<bool> UpdateCustomer(CustomerDto customer)
        {
            _ctx.Update(customer);
            return await SaveAllAsync();
        }

        public async Task<bool> DeleteCustomer(CustomerDto customer)
        {
            _ctx.Remove(customer);
            return await SaveAllAsync();
        }

        private async Task<bool> SaveAllAsync()
        {
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}
