﻿using ModelValidation.Resources;
using System.ComponentModel.DataAnnotations;
using ModelValidation.Resources.DisplayName.ViewModel.Auth;

namespace ModelValidation.Models.ViewModel.Auth
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
        public string? Password { get; set; }
    }
}
