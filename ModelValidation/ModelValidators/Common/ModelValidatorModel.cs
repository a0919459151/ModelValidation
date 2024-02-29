namespace ModelValidation.ModelValidators.Common
{
    public class ModelValidatorResult
    {
        public bool IsValid { get; set; }

        public List<string> Messages { get; set; } = new();
    }
}
