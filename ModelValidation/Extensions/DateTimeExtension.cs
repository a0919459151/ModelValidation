namespace Models.Extensions
{
    /// <summary>
    /// DateTime 擴展方法
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// 之前 (不包含端點)
        /// </summary>
        /// <param name="date">輸入時間</param>
        /// <param name="compareDate">比較時間</param>
        /// <returns></returns>
        public static bool IsBefore(this DateTime date, DateTime compareDate)
        {
            return date.IsBefore(compareDate, false);
        }

        /// <summary>
        /// 之前
        /// </summary>
        /// <param name="date">輸入時間</param>
        /// <param name="compareDate">比較時間</param>
        /// <param name="isInclusive">是否包含端點</param>
        /// <returns></returns>
        public static bool IsBefore(this DateTime date, DateTime compareDate, bool isInclusive)
        {
            return isInclusive ?
                date.Date <= compareDate.Date 
                : date.Date < compareDate.Date;
        }

        /// <summary>
        /// 之後 (不包含端點)
        /// </summary>
        /// <param name="date">輸入時間</param>
        /// <param name="compareDate">比較時間</param>
        /// <returns></returns>
        public static bool IsAfter(this DateTime date, DateTime compareDate)
        {
            return date.IsAfter(compareDate, false);
        }

        /// <summary>
        /// 之後
        /// </summary>
        /// <param name="date">輸入時間</param>
        /// <param name="compareDate">比較時間</param>
        /// <param name="isInclusive">是否包含端點</param>
        public static bool IsAfter(this DateTime date, DateTime compareDate, bool isInclusive)
        {
            return isInclusive ?
                date.Date >= compareDate.Date
                : date.Date > compareDate.Date;
        }

        /// <summary>
        /// 在期間內 (不包含端點)
        /// </summary>
        /// <param name="date">輸入時間</param>
        /// <param name="startDate">開始時間</param>
        /// <param name="endDate">結束時間</param>
        /// <returns></returns>
        public static bool IsBetween(this DateTime date, DateTime startDate, DateTime endDate)
        {
            var isInclusive = false;
            return date.IsBetween(startDate, endDate, isInclusive);
        }

        /// <summary>
        /// 在期間內 
        /// </summary>
        /// <param name="date">輸入時間</param>
        /// <param name="startDate">開始時間</param>
        /// <param name="endDate">結束時間</param>
        /// <param name="isInclusive">是否包含端點</param>
        /// <returns></returns>
        public static bool IsBetween(this DateTime date, DateTime startDate, DateTime endDate, bool isInclusive)
        {
            return date.IsBefore(endDate, isInclusive) && date.IsAfter(startDate, isInclusive); 
        }
    }
}
