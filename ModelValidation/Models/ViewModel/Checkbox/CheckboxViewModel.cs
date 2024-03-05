namespace ModelValidation.Models.ViewModel.Checkbox
{
    public class CheckboxViewModel
    {
        public bool IsChecked { get; set; }

        public bool IsCheckedDisabled { get; set; }

        public bool IsSwitchChecked { get; set; }

        public bool IsSwitchCheckedDisabled { get; set; }

        public bool IsRadioChecked { get; set; }

        public bool IsRadioCheckedDisabled { get; set; }

        public bool IsForceChangePassword { get; set; }

        public int? PasswordChangeTime { get; set; }
    }
}
