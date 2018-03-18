using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.Web.Data.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> CreateCustomer(Entities.Customer customer);
        Task<bool> DeleteCustomer(Entities.Customer customer);
        Task<IEnumerable<Entities.Customer>> GetCustomers();
        Task<bool> UpdateCustomer(Entities.Customer customer);
    }
}