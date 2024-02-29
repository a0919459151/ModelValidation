using ModelValidation.Resources.DisplayName.Enum;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models.Enum
{
    public enum LogLevelEnum
    {
        [Display(Name = LogLevelEnumDisplayName.Critical)]
        Critical,
        [Display(Name = LogLevelEnumDisplayName.Error)]
        Error,
        [Display(Name = LogLevelEnumDisplayName.Warning)]
        Warning,
        [Display(Name = LogLevelEnumDisplayName.Information)]
        Information,
        [Display(Name = LogLevelEnumDisplayName.Debug)]
        Debug
    }
}
