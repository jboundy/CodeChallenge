using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            var created = await _repo.CreateCustomer(customer);
            return StatusCode(created);
        }

        [HttpPost]
        public async Task<IActionResult> GetCustomers()
        {

            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            var data = await _repo.GetCustomers();
            //draw = draw, recordsFiltered = data.Count(), recordsTotal = data.Count(),
            return Json(new {sEcho = 1, iTotalRecords = data.Count(),
                iTotalDisplayRecords = data.Count(), aaData = data});
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerDto customer)
        {
            var updated = await _repo.UpdateCustomer(customer);
            return StatusCode(updated);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(CustomerDto customer)
        {
            var deleted = await _repo.DeleteCustomer(customer);
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
