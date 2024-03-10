using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models.ViewModel.Activity;
using ModelValidation.ModelValidators;
using ModelValidation.Providers;
using ModelValidation.Serivces;

namespace ModelValidation.Controllers
{
    public class ActivityController : Controller
    {
        private readonly ToastrProvider _toastr;
        private readonly ActivityModelValidator _activityModelValidator;
        private readonly ActivityService _activityService;

        public ActivityController(ToastrProvider toastr, ActivityModelValidator activityModelValidator, ActivityService activityService)
        {
            _toastr = toastr;
            _activityModelValidator = activityModelValidator;
            _activityService = activityService;
        }

        public IActionResult ActivityList(ActivityListQueryModel query)
        {
            ActivityListViewModel model = new(query);
            var modelValidateResult = _activityModelValidator.ActivityListQueryModelValidate(query);
            if (!modelValidateResult.IsValid)
            {
                _toastr.Error(modelValidateResult.Messages);
                return View(model);
            }
            model.Activities = _activityService.GetActivityList(query);
            return View(model);
        }

        public IActionResult ActivityPagedList(ActivityPagedListQueryModel query)
        {
            ActivityPagedListViewModel model = new(query);
            var modelValidateResult = _activityModelValidator.ActivityPagedListQueryModelValidate(query);
            if (!modelValidateResult.IsValid)
            {
                _toastr.Error(modelValidateResult.Messages);
                return View(model);
            }
            model.Activities = _activityService.GetActivityPagedList(query);
            return View(model);
        }

        public IActionResult CreateActivity()
        {
            CreateActivityViewModel model = new();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateActivity(CreateActivityViewModel model)
        {
            var validateResult = _activityModelValidator.CommonValidate(model);
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
