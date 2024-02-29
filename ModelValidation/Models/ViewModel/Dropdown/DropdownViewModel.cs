using ModelValidation.Models.Enum;
using ModelValidation.Resources;
using ModelValidation.Resources.DisplayName.ViewModel.Dropdown;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models.ViewModel.Dropdown
{
    public class DropdownViewModel
    {
        [Display(Name = DropdownDisplayName.EnumDropdown)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        public LogLevelEnum EnumDropdown { get; set; } = LogLevelEnum.Information;

        [Display(Name = DropdownDisplayName.EnumDropdown)]
        public LogLevelEnum? EnumDropdownNullable { get; set; } = null;

        [Display(Name = DropdownDisplayName.EnumDropdownMultiple)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        public List<LogLevelEnum> EnumDropdownMultiple { get; set; } = new List<LogLevelEnum>();

        [Display(Name = DropdownDisplayName.EnumDropdownMultiple)]
        public List<LogLevelEnum>? EnumDropdownMultipleNullable { get; set; }

        [Display(Name = DropdownDisplayName.DbDataDropdown)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        public int DbDataDropdownId { get; set; }

        [Display(Name = DropdownDisplayName.DbDataDropdown)]
        public int? DbDataDropdownNullableId { get; set; }

        [Display(Name = DropdownDisplayName.DbDataDropdownMultiple)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        public List<int> DbDataDropdownMultipleId { get; set; } = new List<int>();

        [Display(Name = DropdownDisplayName.DbDataDropdownMultiple)]
        public List<int>? DbDataDropdownMultipleNullableId { get; set; }
    }
}
