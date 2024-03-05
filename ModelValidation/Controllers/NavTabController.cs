using Microsoft.AspNetCore.Mvc;

namespace ModelValidation.Controllers
{
    public class NavTabController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostIndex()
        {
            return View();
        }
    }
}
