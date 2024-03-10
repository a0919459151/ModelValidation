using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models.ViewModel.Auth;
using ModelValidation.ModelValidators;
using ModelValidation.Providers;

namespace ModelValidation.Controllers
{
    public class AuthController : Controller
    {
        private readonly ToastrProvider _toastr;
        private readonly AuthModelValidator _authModelValidator;

        public AuthController(ToastrProvider toastr, AuthModelValidator authModelValidator)
        {
            _toastr = toastr;
            _authModelValidator = authModelValidator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            var model = new SignUpViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(SignUpViewModel model)
        {
            var validateResult = _authModelValidator.CommonValidate(model);
            if (!validateResult.IsValid)
            {
                _toastr.Error(validateResult.Messages);
                return View(model);
            }
            _toastr.Success();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignIn()
        {
            var model = new SignInViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(SignInViewModel model)
        {
            var validateResult = _authModelValidator.CommonValidate(model);
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
