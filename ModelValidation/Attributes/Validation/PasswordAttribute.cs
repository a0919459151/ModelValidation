using ModelValidation.Resource;

namespace System.ComponentModel.DataAnnotations
{
    public class PasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null || value is not string password)
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errorMessage);
            }

            if (password.Length < 8)
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errorMessage);
            }

            // 如果密碼滿足條件，返回成功
            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return CustomErrorMessage.Password;
        }
    }
}
