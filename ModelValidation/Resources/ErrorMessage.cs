namespace ModelValidation.Resources
{
    public static class ErrorMessage
    {
        /* Common */
        public const string CommonInvalid = "{0}輸入有誤";

        /* Required attribute */
        public const string Required = "{0}為必填";

        /* EmailAddress attribute */
        public const string Email = "{0}格式錯誤";

        /* Compare attribute */
        public const string ConfirmPassword = "密碼與確認密碼不一致";

        /* StringLength attribute */
        public const string StringLength = "{0}長度需小於{1}";
        public const string StringLengthMinimum = "{0}長度需介於{2}到{1}之間";

        /* RegularExpression attribute */
        public const string Phone = "{0}格式錯誤";
    }

    public static class CustomErrorMessage
    {
        /* Password attribute */
        public const string Password = "密碼格式錯誤";

        /* Editor required */
        public const string EditorRequired = "文字編輯器內容為必填";

        /* List required */
        public const string ListRequired = "{0}為必填";
    }
}
