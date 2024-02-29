using ModelValidation.Resources;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidation.ModelValidators.Common
{
    public class CommonModelValidator
    {
        public ModelValidatorResult CommonValidate(object model)
        {
            var errorMessages = new List<string>();

            // Get view model all property by reflection
            var properties = model.GetType().GetProperties();

            foreach (var property in properties)
            {
                string propertyName = property!.GetCustomAttribute<DisplayAttribute>()?.Name ?? property!.Name;

                // Get all data annotation attribute for each property
                var attributes = property.GetCustomAttributes(typeof(ValidationAttribute), true);

                foreach (ValidationAttribute attribute in attributes)
                {
                    var propertyValue = property.GetValue(model);
                    string errorMessage;

                    errorMessage = CommonValidate(attribute, propertyValue, propertyName);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        errorMessages.Add(errorMessage);
                        continue;
                    }

                    errorMessage = ListRequiredValidate(attribute, property, model, propertyName);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        errorMessages.Add(errorMessage);
                        continue;
                    }
                }
            }

            return new()
            {
                IsValid = errorMessages.Count == 0,
                Messages = errorMessages
            };
        }

        private string CommonValidate(ValidationAttribute attribute, object? propertyValue, string propertyName)
        {
            if (attribute is not CompareAttribute
                && !attribute.IsValid(propertyValue))
            {
                return string.Format(ErrorMessage.CommonInvalid, propertyName);
            }

            return string.Empty;
        }

        private string ListRequiredValidate(ValidationAttribute attribute, PropertyInfo property, object model, string propertyName)
        {
            // Implementation from previous explanation
            var propertyType = property.PropertyType;
            var propertyValue = property.GetValue(model) as IEnumerable;

            var isRequired = attribute is RequiredAttribute;
            var isEnumerableType = typeof(IEnumerable).IsAssignableFrom(propertyType) && propertyType != typeof(string);
            var isEmptyList = propertyValue == null || !propertyValue.GetEnumerator().MoveNext();

            if (isRequired && isEnumerableType && isEmptyList)
            {
                var errorMessage = attribute.ErrorMessage ?? ErrorMessage.Required;
                return string.Format(errorMessage, propertyName);
            }

            return string.Empty;
        }
    }
}
