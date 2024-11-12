
using Microsoft.AspNetCore.Mvc;

namespace poe.Controllers
{

    public class ProductDisplayController : Controller
    {
        [HttpGet]
        public IActionResult MyWork()
        {
            var products = ProductDisplayModel.SelectProducts();
            return View(products);
        }
    }
}

