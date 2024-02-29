using ModelValidation.Resources;
using System.ComponentModel.DataAnnotations;
using ModelValidation.Resources.DisplayName.ViewModel.DateTime;

namespace ModelValidation.Models.ViewModel.DataTime
{
    public class DateTimeViewModel
    {
        [Display(Name = DateTimeDisplayName.DateTime)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; } = System.DateTime.MinValue;

        [Display(Name = DateTimeDisplayName.Date)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = System.DateTime.MinValue;

        [Display(Name = DateTimeDisplayName.Time)]
        [Required(ErrorMessage = ErrorMessage.Required)]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; } = System.DateTime.MinValue;

        [Display(Name = DateTimeDisplayName.DateTime)]
        [DataType(DataType.DateTime)]
        public DateTime? DateTimeNullable { get; set; }

        [Display(Name = DateTimeDisplayName.Date)]
        [DataType(DataType.Date)]
        public DateTime? DateNullable { get; set; }

        [Display(Name = DateTimeDisplayName.Time)]
        [DataType(DataType.Time)]
        public DateTime? TimeNullable { get; set; }
    }
}
