using Microsoft.AspNetCore.Mvc;
using st10158209.Models;

namespace st10158209.Controllers
{ 
    public class LoginController:Controller
    {


        private readonly LoginModel login;

        public LoginController()
        {
            login = new LoginModel();
        }

        [HttpPost]
        public ActionResult Index(string Name, string Email, string PhoneNumber)
        {
            var LoginModel = new LoginModel();
            int UserID = LoginModel.SelectUser(Name, Email, PhoneNumber);
            if (UserID != -1)
            {
                // User found, proceed with login logic (e.g., set authentication cookie)
                // For demonstration, redirecting to a dummy page
                return RedirectToAction("MyWork", "Home", new { UserID = UserID });

            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username, email, or password. Please check your credentials and try again.";

                return RedirectToAction("LoginFailed", "Home");
            }

        }
    }
}

