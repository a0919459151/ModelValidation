using ModelValidation.Models.ViewModel.Activity;
using ModelValidation.ModelValidators.Common;
using ModelValidation.Resources;

namespace ModelValidation.ModelValidators
{
    public class ActivityModelValidator : CommonModelValidator
    {
        public ModelValidatorResult ActivityListQueryModelValidate(ActivityListQueryModel model)
        {
            var result = new ModelValidatorResult();

            // check StartAt is less than EndAt
            if (model.StartAt is not null
                && model.EndAt is not null
                && model.StartAt.Value > model.EndAt.Value)
            {
                result.Messages.Add("StartAt must be less than or equal to EndAt");
                return result;
            }

            return result;
        }

        public ModelValidatorResult ActivityPagedListQueryModelValidate(ActivityPagedListQueryModel model)
        {
            var result = new ModelValidatorResult();

            if (model.PageNumber < 1)
            {
                result.Messages.Add("PageNumber must be greater than 0");
            }
            if (model.PageSize < 1)
            {
                result.Messages.Add("PageSize must be greater than 0");
            }

            // check StartAt is less than EndAt
            if (model.StartAt is not null
                && model.EndAt is not null
                && model.StartAt.Value > model.EndAt.Value)
            {
                result.Messages.Add("StartAt must be less than or equal to EndAt");
            }

            return result;
        }
    }
}
