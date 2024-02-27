using ModelValidation.Resource.DisplayName.Auth;
using ModelValidation.Resource;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models.Auth
{
    public class SignInViewModel
    {
        [Display(Name = SignUpDisplayName.Email)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        [EmailAddress(ErrorMessage = ErrorMessage.Email)]
        public string? Email { get; set; }

        [Display(Name = SignUpDisplayName.Password)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        [DataType(DataType.Password)]
        [Password]
        public string? Password { get; set; }
    }
}
