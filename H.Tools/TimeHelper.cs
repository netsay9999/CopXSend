using System;

namespace H.Saas.Tools
{
    /// <summary>
    /// 时间戳
    /// </summary>
    public static class TimeHelper
    {
        /// <summary>
        /// 获取当前时间戳
        /// Add by 成长的小猪（Jason.Song） on 2019/05/07
        /// http://blog.csdn.net/jasonsong2008
        /// </summary>
        /// <param name="millisecond">精度（毫秒）设置 true，则生成13位的时间戳；精度（秒）设置为 false，则生成10位的时间戳；默认为 true </param>
        /// <returns></returns>
        public static string GetCurrentTimestamp(bool millisecond = true)
        {
            return DateTime.Now.ToTimestamp(millisecond);
        }

        public static int GetCurrentIntTimestamp(bool millisecond = true)
        {
            return Convert.ToInt32(DateTime.Now.ToTimestamp(millisecond));
        }

        public static int ToIntTimeStamp(this string dateTime, bool millisecond = false)
        {
            var time = Convert.ToDateTime(dateTime);
            return Convert.ToInt32(time.ToTimestampLong(millisecond));
        }
        /// <summary>
        /// 转换指定时间得到对应的时间戳
        /// Add by 成长的小猪（Jason.Song） on 2019/05/07
        /// http://blog.csdn.net/jasonsong2008
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="millisecond">精度（毫秒）设置 true，则生成13位的时间戳；精度（秒）设置为 false，则生成10位的时间戳；默认为 true </param>
        /// <returns>返回对应的时间戳</returns>
        public static string ToTimestamp(this DateTime dateTime, bool millisecond = false)
        {
            return dateTime.ToTimestampLong(millisecond).ToString();
        }
        public static string ToStrTimestamp(this string dateTime, bool millisecond = false)
        {
            return Convert.ToDateTime(dateTime).ToTimestampLong(millisecond).ToString();
        }
        /// <summary>
        /// 转换指定时间得到对应的时间戳
        /// Add by 成长的小猪（Jason.Song） on 2019/05/07
        /// http://blog.csdn.net/jasonsong2008
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="millisecond">精度（毫秒）设置 true，则生成13位的时间戳；精度（秒）设置为 false，则生成10位的时间戳；默认为 true </param>
        /// <returns>返回对应的时间戳</returns>
        public static long ToTimestampLong(this DateTime dateTime, bool millisecond = false)
        {
            var ts = dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return millisecond ? Convert.ToInt64(ts.TotalMilliseconds) : Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// 转换指定时间戳到对应的时间
        /// Add by 成长的小猪（Jason.Song） on 2019/05/07
        /// http://blog.csdn.net/jasonsong2008
        /// </summary>
        /// <param name="timestamp">（10位或13位）时间戳</param>
        /// <returns>返回对应的时间</returns>
        public static DateTime ToDateTime(this object timestampss)
        {
            var timestamp = timestampss.ToString();
            var tz = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            return timestamp.Length == 13
                ? tz.AddMilliseconds(Convert.ToInt64(timestamp))
                : tz.AddSeconds(Convert.ToInt64(timestamp));
        }
        public static DateTime ToIntDateTime(this int timestamp)
        {
            var tz = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            return timestamp.ToString().Length == 13
                ? tz.AddMilliseconds(Convert.ToInt64(timestamp))
                : tz.AddSeconds(Convert.ToInt64(timestamp));
        }
    }

}
