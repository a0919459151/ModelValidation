using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models.ViewModel.Activity;
using ModelValidation.ModelValidators.Common;

namespace ModelValidation.Controllers
{
    public class ActivityController : Controller
    {
        private readonly ToastrProvider _toastr;
        private readonly CommonModelValidator _commonModelValidator;

        public ActivityController(ToastrProvider toastr, CommonModelValidator modelValidator)
        {
            _toastr = toastr;
            _commonModelValidator = modelValidator;
        }

        public IActionResult CreateActivity()
        {
            var model = new CreateActivityViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateActivity(CreateActivityViewModel model)
        {
            var validateResult = _commonModelValidator.CommonValidate(model);
            if (!validateResult.IsValid)
            {
                _toastr.Error(validateResult.Messages);
                return View(model);
            }
            _toastr.Success();
            return RedirectToAction("Index", "Home");
        }
    }
}
