using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models.DataTime;

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
        public IActionResult PostIndex()
        {
            return View();
        }
    }
}
