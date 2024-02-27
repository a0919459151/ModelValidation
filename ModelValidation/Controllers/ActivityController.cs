using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models.Activity;

namespace ModelValidation.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult CreateActivity()
        {
            var model = new CreateActivityViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateActivity(CreateActivityViewModel model)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
