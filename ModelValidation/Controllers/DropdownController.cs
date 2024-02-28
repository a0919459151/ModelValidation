using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models.ViewModel.Dropdown;

namespace ModelValidation.Controllers
{
    public class DropdownController : Controller
    {
        public IActionResult Index()
        {
            var model = new DropdownViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostIndex(DropdownViewModel model)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
