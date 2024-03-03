using ModelValidation.Providers;
using ModelValidation.Resources.DisplayName.ViewModel.Activity;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace ModelValidation.Models.ViewModel.Activity
{
    public class ActivityPagedListViewModel(ActivityPagedListQueryModel query)
    {
        public ActivityPagedListQueryModel Query { get; } = query;

        public IPagedList<ActivityModel>? Activities { get; set; }
    }

    public class ActivityPagedListQueryModel : IPagedListQuery
    {
        [Display(Name = ActivityListDisplayName.Name)]
        public string? Name { get; set; }

        public int PageNumber { get; set; } = PagerConstants.DefaultPageNumber;

        public int PageSize { get; set; } = PagerConstants.DefaultPageNumber;
    }
}
