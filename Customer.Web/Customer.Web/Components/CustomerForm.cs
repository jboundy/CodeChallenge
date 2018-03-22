using Microsoft.AspNetCore.Mvc;

namespace Customer.Web.Components
{
    public class CustomerForm : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("CustomerFormVC");
        }
    }
}
