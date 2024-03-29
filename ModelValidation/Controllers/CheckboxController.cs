﻿using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models.ViewModel.Checkbox;
using ModelValidation.ModelValidators;
using ModelValidation.Providers;

namespace ModelValidation.Controllers
{
    public class CheckboxController : Controller
    {
        private readonly ToastrProvider _toastr;
        private readonly CheckboxModelValidator _checkboxModelValidator;

        public CheckboxController(ToastrProvider toastr, CheckboxModelValidator checkboxModelValidator)
        {
            _toastr = toastr;
            _checkboxModelValidator = checkboxModelValidator;
        }

        public IActionResult Index()
        {
            var model = new CheckboxViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostIndex(CheckboxViewModel model)
        {
            var validateResult = _checkboxModelValidator.CommonValidate(model);
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
