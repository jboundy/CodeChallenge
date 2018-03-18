using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Web.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IEnumerable<Data.Entities.Customer>> GetCustomers()
        {
            return await _repo.GetCustomers();           
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Data.Entities.Customer customer)
        {
            var created = await _repo.CreateCustomer(customer);
            if (created)
            {
                return Created("/", customer);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Data.Entities.Customer customer)
        {
            var updated = await _repo.UpdateCustomer(customer);
            if (updated)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Data.Entities.Customer customer)
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
