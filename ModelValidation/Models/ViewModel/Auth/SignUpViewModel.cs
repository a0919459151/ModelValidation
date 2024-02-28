using ModelValidation.Resource;
using ModelValidation.Resource.DisplayName.ViewModel.Auth;
using ModelValidation.Resource.RegexTemplate;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models.ViewModel.Auth
{
    public class SignUpViewModel
    {
        [Display(Name = SignUpDisplayName.Name)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        [StringLength(10, MinimumLength = 3, ErrorMessage = ErrorMessage.StringLengthMinimum)]
        public string? Name { get; set; }

        [Display(Name = SignUpDisplayName.Email)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        [EmailAddress(ErrorMessage = ErrorMessage.Email)]
        public string? Email { get; set; }

        [Display(Name = SignUpDisplayName.Password)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        [DataType(DataType.Password)]
        [Password]
        public string? Password { get; set; }

        [Display(Name = SignUpDisplayName.ConfirmPassword)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = ErrorMessage.ConfirmPassword)]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = ErrorMessage.Required)]
        [Display(Name = SignUpDisplayName.Phone)]
        [RegularExpression(RegexTemplate.Phone, ErrorMessage = ErrorMessage.Phone)]
        [Phone]
        public string? Phone { get; set; }

        [Display(Name = SignUpDisplayName.Birthday)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        [DataType(DataType.DateTime)]
        public DateTime? Birthday { get; set; }
    }
}
