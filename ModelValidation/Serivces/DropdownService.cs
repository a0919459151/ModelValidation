using Microsoft.AspNetCore.Mvc.Rendering;

namespace ModelValidation.Serivces
{
    public class DropdownService
    {
        public List<SelectListItem> GetActivityDropdownItems()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Text = "1", Value = "Activity1" },
                new SelectListItem { Text = "2", Value = "Activity2" },
                new SelectListItem { Text = "3", Value = "Activity3" },
                new SelectListItem { Text = "4", Value = "Activity4" },
                new SelectListItem { Text = "5", Value = "Activity5" },
            };
        }

    }
}
