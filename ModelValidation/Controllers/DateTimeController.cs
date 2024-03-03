using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models.ViewModel.DataTime;
using ModelValidation.ModelValidators.Common;
using ModelValidation.Providers;

namespace ModelValidation.Controllers
{
    public class DateTimeController : Controller
    {
        private readonly ToastrProvider _toastr;
        private readonly CommonModelValidator _commonModelValidator;


        public DateTimeController(ToastrProvider toastr, CommonModelValidator modelValidator)
        {
            _toastr = toastr;
            _commonModelValidator = modelValidator;
        }

        public IActionResult Index()
        {
            var model = new DateTimeViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostIndex(DateTimeViewModel model)
        {
            var validateResult = _commonModelValidator.CommonValidate(model);
            if (!validateResult.IsValid)
            {
                _toastr.Error(validateResult.Messages);
                return RedirectToAction(nameof(Index));
            }
            _toastr.Success();
            return RedirectToAction("Index", "Home");
        }
    }
}
