using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models.ViewModel.Activity;
using ModelValidation.ModelValidators.Common;
using ModelValidation.Providers;
using ModelValidation.Serivces;

namespace ModelValidation.Controllers
{
    public class ActivityController : Controller
    {
        private readonly ToastrProvider _toastr;
        private readonly CommonModelValidator _commonModelValidator;
        private readonly ActivityService _activityService;

        public ActivityController(ToastrProvider toastr, CommonModelValidator modelValidator, ActivityService activityService)
        {
            _toastr = toastr;
            _commonModelValidator = modelValidator;
            _activityService = activityService;
        }

        public IActionResult ActivityList(ActivityListQueryModel query)
        {
            var model = new ActivityListViewModel(query);
            model.Activities = _activityService.GetActivityList(query);
            return View(model);
        }

        public IActionResult ActivityPagedList(ActivityPagedListQueryModel query)
        {
            var model = new ActivityPagedListViewModel(query);
            model.Activities = _activityService.GetActivityPagedList(query);
            return View(model);
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
