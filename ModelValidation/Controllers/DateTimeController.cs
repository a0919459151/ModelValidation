using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models.ViewModel.DataTime;

namespace ModelValidation.Controllers
{
    public class DateTimeController : Controller
    {
        public IActionResult Index()
        {
            var model = new DateTimeViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostIndex(DateTimeViewModel model)
        {
            return View();
        }
    }
}
