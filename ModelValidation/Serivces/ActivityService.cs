using ModelValidation.Extensions;
using ModelValidation.Models.ViewModel.Activity;
using ModelValidation.Providers;
using X.PagedList;

namespace ModelValidation.Serivces
{
    public class ActivityService
    {
        private List<ActivityModel> ActivityReposotory => [
            new ActivityModel { Id = 1, Name = "Activity 1" },
            new ActivityModel { Id = 2, Name = "Activity 2" },
            new ActivityModel { Id = 3, Name = "Activity 3" },
            new ActivityModel { Id = 4, Name = "Activity 4" },
            new ActivityModel { Id = 5, Name = "Activity 5" },
            new ActivityModel { Id = 6, Name = "Activity 6" },
            new ActivityModel { Id = 7, Name = "Activity 7" },
            new ActivityModel { Id = 8, Name = "Activity 8" },
            new ActivityModel { Id = 9, Name = "Activity 9" },
            new ActivityModel { Id = 10, Name = "Activity 10" },
            new ActivityModel { Id = 11, Name = "Activity 11" },
            new ActivityModel { Id = 12, Name = "Activity 12" },
            new ActivityModel { Id = 13, Name = "Activity 13" },
            new ActivityModel { Id = 14, Name = "Activity 14" },
            new ActivityModel { Id = 15, Name = "Activity 15" },
        ];

        public List<ActivityModel> GetActivityList(ActivityListQueryModel query)
        {
            var result = ActivityReposotory
                .WhereIf(query.Name != null, a => a.Name!.Contains(query.Name!))
                .ToList();
            return result;
        }

        public IPagedList<ActivityModel> GetActivityPagedList(ActivityPagedListQueryModel query)
        {
            var result = ActivityReposotory
                .WhereIf(query.Name != null, a => a.Name!.Contains(query.Name!))
                .ToPagedList(PagerConstants.DefaultPageNumber, PagerConstants.DefaultPageSize);
            return result;
        }
    }
}
