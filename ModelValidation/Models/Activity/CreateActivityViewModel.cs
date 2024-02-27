using ModelValidation.Resource;
using ModelValidation.Resource.DisplayName.Activity;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models.Activity
{
    public class CreateActivityViewModel
    {
        [Display(Name = CreateActivityDisplayName.Name)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        [StringLength(10, ErrorMessage = ErrorMessage.StringLength)]
        public string? Name { get; set; }

        [Display(Name = CreateActivityDisplayName.Description)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        public string? Description { get; set; }

        [Display(Name = CreateActivityDisplayName.BusinessHours)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        [StringLength(100, ErrorMessage = ErrorMessage.StringLength)]
        [DataType(DataType.MultilineText)]
        public string? BusinessHours { get; set; }
    }
}
