using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Web.Data.Entities;
using Customer.Web.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Customer.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerRepository _repo;

        public HomeController(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            return await _repo.GetCustomers();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]CustomerDto customer)
        {
            var created = await _repo.CreateCustomer(customer);
            if (created)
            {
                return Created("/", customer);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerDto customer)
        {
            var updated = await _repo.UpdateCustomer(customer);
            if (updated)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(CustomerDto customer)
        {
            var deleted = await _repo.DeleteCustomer(customer);
            if (deleted)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
