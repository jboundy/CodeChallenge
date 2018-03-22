using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Web.Data.Entities;

namespace Customer.Web.Data.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> CreateCustomerAsync(CustomerDto customer);
        Task<IEnumerable<CustomerDto>> GetCustomersAsync();
        Task<bool> UpdateCustomerAsync(CustomerDto customer);
        Task<bool> DeleteCustomerAsync(CustomerDto customer);
    }
}
