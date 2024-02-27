using ModelValidation.Resource;
using System.ComponentModel.DataAnnotations;
using ModelValidation.Resource.DisplayName.DateTime;

namespace ModelValidation.Models.DataTime
{
    public class DateTimeViewModel
    {
        [Display(Name = DateTimeDisplayName.DateTime)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        [DataType(DataType.DateTime)]
        public DateTime? DateTime { get; set; }

        [Display(Name = DateTimeDisplayName.Date)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Display(Name = DateTimeDisplayName.Time)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        [DataType(DataType.Time)]
        public DateTime? Time { get; set; }
    }
}
