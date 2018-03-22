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
        public async Task<bool> CreateCustomerAsync(CustomerDto customer)
        {
            await _ctx.AddAsync(customer);
            return await SaveAllAsync();
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()
        {
            return await _ctx.Customers.ToListAsync();
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            return await _ctx.Customers.FirstOrDefaultAsync(dto => dto.Id == id);
        }

        public async Task<bool> UpdateCustomerAsync(CustomerDto customer)
        {
            _ctx.Update(customer);
            return await SaveAllAsync();
        }

        public async Task<bool> DeleteCustomerAsync(CustomerDto customer)
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
