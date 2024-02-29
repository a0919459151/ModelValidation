using Microsoft.AspNetCore.Mvc.Rendering;

namespace ModelValidation.Serivces
{
    public class DropdownService
    {
        public List<SelectListItem> GetActivityDropdownItems()
        {
            // Mock db access
            return new List<SelectListItem>
            {
                new SelectListItem { Value= "1", Text  = "Activity1" },
                new SelectListItem { Value= "2", Text  = "Activity2" },
                new SelectListItem { Value= "3", Text  = "Activity3" },
                new SelectListItem { Value= "4", Text  = "Activity4" },
                new SelectListItem { Value= "5", Text  = "Activity5" }
            };
        }

    }
}
