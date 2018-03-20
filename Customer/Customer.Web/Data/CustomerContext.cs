using Customer.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer.Web.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
            
        }
        public DbSet<CustomerDto> Customers { get;set; }
    }
}
