using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using X.PagedList;
using X.PagedList.Mvc.Core;
using X.PagedList.Web.Common;

namespace ModelValidation.Providers
{
    public class PagerProvider
    {
        private readonly IHtmlHelper _htmlHelper;
        private readonly IUrlHelper _urlHelper;
        private readonly IHttpContextAccessor? _httpContextAccessor;

        private PagedListRenderOptions Options 
            => new() { LiElementClasses = ["page-item"], PageClasses = ["page-link"] };

        private IPagedList PagedList { get; set; }
        private IPagedListQuery QueryModel { get; set; }

        public PagerProvider(
            IHtmlHelper htmlHelper,
            IActionContextAccessor actionContextAccessor,
            IUrlHelperFactory urlHelperFactory,
            IHttpContextAccessor? httpContextAccessor)
        {
            _htmlHelper = htmlHelper;
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext ?? throw new Exception("ActionContext not found")) ;
            _httpContextAccessor = httpContextAccessor;
        }

        // init
        public void Init(IPagedList? pagedList, IPagedListQuery queryModel)
        {
            PagedList = pagedList ?? GetEmptyPagedList();
            QueryModel = queryModel;
        }   

        public string GetPagerInfo()
        {
            return string.Format(
                PagerConstants.PagerInfoFormat,
                PagedList.TotalItemCount,
                PagedList.PageSize,
                PagedList.PageCount);
        }

        public HtmlString CreatePager()
        {
            return _htmlHelper.PagedListPager(PagedList, GeneratePageUrl(), Options);
        }

        private PagedList<object> GetEmptyPagedList()
        {
            return new PagedList<object>([], 1, 1);
        }

        private Func<int, string> GeneratePageUrl()
        {
            return page =>
            {
                var actionName = GetActionName();
                QueryModel.PageNumber = page;
                return _urlHelper.Action(actionName, QueryModel) ?? throw new Exception("Action not found");
            };
        }

        private string? GetActionName()
        {
            string? actionName = _httpContextAccessor?.HttpContext?.Request.RouteValues["action"]?.ToString();
            return actionName;
        }
    }

    public interface IPagedListQuery
    {
        int PageNumber { get; set; }

        int PageSize { get; set; }
    }

    public static class PagerConstants
    {
        public const int DefaultPageNumber = 1;

        public const int DefaultPageSize = 10;

        public const string PagerInfoFormat = "共{0}筆，每頁{1}筆，共{2}頁";
    }
}
