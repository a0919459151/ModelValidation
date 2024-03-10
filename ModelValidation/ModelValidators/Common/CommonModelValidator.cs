using ModelValidation.Resources;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidation.ModelValidators.Common
{
    public abstract class CommonModelValidator
    {
        private object? CurrentModel { get; set; }
        private PropertyInfo? CurrentProperty { get; set; }
        private string? CurrentPropertyName { get; set; }
        private object? CurrentPropertyValue { get; set; }
        private ValidationAttribute? CurrentAttribute { get; set; }


        public ModelValidatorResult CommonValidate(object model)
        {
            var errorMessages = new List<string>();
            CurrentModel = model;

            // Get view model all property by reflection
            var properties = model.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                CurrentProperty = property;
                CurrentPropertyName = property!.GetCustomAttribute<DisplayAttribute>()?.Name ?? property!.Name;

                // Get all data annotation attribute for each property
                var attributes = property.GetCustomAttributes(typeof(ValidationAttribute), true);

                foreach (ValidationAttribute attribute in attributes)
                {
                    string errorMessage;

                    CurrentAttribute = attribute;
                    CurrentPropertyValue = property.GetValue(model);

                    errorMessage = CommonValidate();
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        errorMessages.Add(errorMessage);
                    }

                    errorMessage = ListRequiredValidate();
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        errorMessages.Add(errorMessage);
                    }

                    errorMessage = DatetimeRequiredValidate();
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        errorMessages.Add(errorMessage);
                    }
                }
            }

            return new()
            {
                Messages = errorMessages
            };
        }

        private string CommonValidate()
        {
            List<Type> validAttributes = [
                typeof(RequiredAttribute), 
                typeof(StringLengthAttribute), 
                typeof(RegularExpressionAttribute), 
                typeof(RangeAttribute), 
                typeof(EmailAddressAttribute)];

            if (CurrentAttribute is null) return string.Empty;

            if (validAttributes.Contains(CurrentAttribute.GetType())
                && !CurrentAttribute!.IsValid(CurrentPropertyValue))
            {
                return GetCommonInvalidMessage();
            }

            return string.Empty;
        }

        private string ListRequiredValidate()
        {
            var propertyType = CurrentProperty!.PropertyType;
            var listValue = CurrentPropertyValue as IEnumerable;

            var isRequired = CurrentAttribute is RequiredAttribute;
            var isEnumerableType = typeof(IEnumerable).IsAssignableFrom(propertyType) && propertyType != typeof(string);
            var isEmptyList = listValue == null || !listValue.GetEnumerator().MoveNext();

            if (isRequired && isEnumerableType && isEmptyList)
            {
                return GetCommonInvalidMessage();
            }

            return string.Empty;
        }

        private string DatetimeRequiredValidate()
        {
            List<DataType> validDataTypes = [DataType.Date, DataType.DateTime];

            if (CurrentAttribute is not DataTypeAttribute dataTypeAttribute) return string.Empty;
            if (CurrentPropertyValue is not DateTime dateTimeValue) return string.Empty;

            var isDateTime = validDataTypes.Contains(dataTypeAttribute.DataType);

            if (isDateTime
                && dateTimeValue == System.DateTime.MinValue)
            {
                return GetCommonInvalidMessage();
            }

            return string.Empty;
        }

        private string GetCommonInvalidMessage()
        {
            return string.Format(ErrorMessage.CommonInvalid, CurrentPropertyName);
        }
    }
}
