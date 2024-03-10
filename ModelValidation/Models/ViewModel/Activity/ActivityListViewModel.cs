using ModelValidation.Resources.DisplayName.ViewModel.Activity;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models.ViewModel.Activity
{
    public class ActivityListViewModel(ActivityListQueryModel query)
    {
        public ActivityListQueryModel Query { get; } = query;

        public List<ActivityModel>? Activities { get; set; }
    }

    public class ActivityListQueryModel
    {
        [Display(Name = ActivityListDisplayName.Name)]
        public string? Name { get; set; }

        [Display(Name = ActivityListDisplayName.StartAt)]
        public DateTime? StartAt { get; set; }

        [Display(Name = ActivityListDisplayName.EndAt)]
        public DateTime? EndAt { get; set; }
    }

    public class ActivityModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime? StartAt { get; set; }

        public DateTime? EndAt { get; set; }
    }
}
