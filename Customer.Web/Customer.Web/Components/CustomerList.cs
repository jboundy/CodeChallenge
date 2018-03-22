using Customer.Web.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Web.Components
{
    public class CustomerList : ViewComponent
    {
        private ICustomerRepository _repo;

        public CustomerList(ICustomerRepository repo)
        {
            _repo = repo;
        }
        public IViewComponentResult Invoke()
        {
            return View("CustomerListVC", _repo.GetCustomersAsync());
        }
    }
}
