using Microsoft.AspNetCore.Mvc;
using st10158209.Models;

namespace st10158209.Controllers
{
    public class CustomerProfileController : Controller
    {
        public CustomerProfile CustomerProfile = new CustomerProfile();


        
        [HttpPost]
        public IActionResult SignUp(CustomerProfile Users)
        {
            var result = CustomerProfile.insert_User(Users);

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View(CustomerProfile);
        }

    }
}
