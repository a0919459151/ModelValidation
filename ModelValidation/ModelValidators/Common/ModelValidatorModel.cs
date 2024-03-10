namespace ModelValidation.ModelValidators.Common
{
    public class ModelValidatorResult
    {
        public bool IsValid => Messages.Count == 0;
               
        public List<string> Messages { get; set; } = new();
    }
}
