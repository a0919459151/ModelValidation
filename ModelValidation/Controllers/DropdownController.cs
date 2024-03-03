using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models.ViewModel.Dropdown;
using ModelValidation.ModelValidators;
using ModelValidation.Providers;

namespace ModelValidation.Controllers
{
    public class DropdownController : Controller
    {
        private readonly ToastrProvider _toastr;
        private readonly DropdownModelValidator _dropdownModelValidator;


        public DropdownController(ToastrProvider toastrProvider, DropdownModelValidator dropdownModelValidator)
        {
            _toastr = toastrProvider;
            _dropdownModelValidator = dropdownModelValidator;
        }

        public IActionResult Index()
        {
            var model = new DropdownViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostIndex(DropdownViewModel model)
        {
            var validateResult =  _dropdownModelValidator.CommonValidate(model);
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
