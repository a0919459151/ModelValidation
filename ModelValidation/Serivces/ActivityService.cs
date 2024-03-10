using ModelValidation.Extensions;
using ModelValidation.Models.ViewModel.Activity;
using X.PagedList;

namespace ModelValidation.Serivces
{
    public class ActivityService
    {
        private static List<ActivityModel> _activityReposotory = GenerateActivities(30);

        #region Mock reposotory
        // get radom data for demo
        // - radom StartAt between  +- 1 month
        // - radom EndAt between StartAt + 1 day and StartAt + 7 day
        private static List<ActivityModel> GenerateActivities(int count)
        {
            var rng = new Random();
            var activities = new List<ActivityModel>();
            for (int i = 1; i <= count; i++)
            {
                int startOffsetDays = rng.Next(-30, 30);
                DateTime startAt = DateTime.Now.AddDays(startOffsetDays);

                int durationDays = rng.Next(1, 8);
                DateTime endAt = startAt.AddDays(durationDays);

                activities.Add(new ActivityModel
                {
                    Id = i,
                    Name = $"活動{i}",
                    StartAt = startAt,
                    EndAt = endAt
                });
            }

            return activities;
        }
        #endregion

        public List<ActivityModel> GetActivityList(ActivityListQueryModel query)
        {
            var result = _activityReposotory
                .WhereIf(query.Name != null, a => a.Name!.Contains(query.Name!))
                .WhereIf(query.StartAt != null, a => a.StartAt!.Value.Date >= query.StartAt!.Value.Date)
                .WhereIf(query.EndAt != null, a => a.EndAt!.Value.Date <= query.EndAt!.Value.Date)
                .ToList();
            return result;
        }

        public IPagedList<ActivityModel> GetActivityPagedList(ActivityPagedListQueryModel query)
        {
            var result = _activityReposotory
                .WhereIf(query.Name != null, a => a.Name!.Contains(query.Name!))
                .WhereIf(query.StartAt != null, a => a.StartAt!.Value.Date >= query.StartAt!.Value.Date)
                .WhereIf(query.EndAt != null, a => a.EndAt!.Value.Date <= query.EndAt!.Value.Date)
                .ToPagedList(query.PageNumber, query.PageSize);
            return result;
        }
    }
}
