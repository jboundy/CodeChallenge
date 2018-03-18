using Microsoft.EntityFrameworkCore;

namespace Customer.Web.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
            
        }
        public DbSet<Entities.Customer> Customers { get;set; }
    }
}
