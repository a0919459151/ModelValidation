using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models.ViewModel.DataTime;
using ModelValidation.ModelValidators;
using ModelValidation.Providers;

namespace ModelValidation.Controllers
{
    public class DateTimeController : Controller
    {
        private readonly ToastrProvider _toastr;
        private readonly DateTimeModelValidator _dateTimeModelValidator;


        public DateTimeController(ToastrProvider toastr, DateTimeModelValidator dateTimeModelValidator)
        {
            _toastr = toastr;
            _dateTimeModelValidator = dateTimeModelValidator;
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
            var validateResult = _dateTimeModelValidator.CommonValidate(model);
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
