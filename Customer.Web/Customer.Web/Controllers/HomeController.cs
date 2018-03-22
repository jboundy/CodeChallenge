using System.Diagnostics;
using System.Threading.Tasks;
using Customer.Web.Data.Entities;
using Customer.Web.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Customer.Web.Models;

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

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CustomerDto customer)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _repo.CreateCustomerAsync(customer);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return new JsonResult(await _repo.GetCustomersAsync());
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerDto customer)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _repo.UpdateCustomerAsync(customer);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(CustomerDto customer)
        {
            var deleted = await _repo.DeleteCustomerAsync(customer);
            return StatusCode(deleted);
        }

        public IActionResult CustomerListViewComponent()
        {
            return ViewComponent("CustomerListVC");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private IActionResult StatusCode(bool success)
        {
            if (success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
