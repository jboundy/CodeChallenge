using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Web.Data.Entities;

namespace Customer.Web.Data.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> CreateCustomer(CustomerDto customer);
        Task<bool> DeleteCustomer(CustomerDto customer);
        Task<IEnumerable<CustomerDto>> GetCustomers();
        Task<bool> UpdateCustomer(CustomerDto customer);
    }
}