using NodaTime;
using System;
namespace H.Saas.Tools
{

    /// <summary>
    /// 时间相关的操作类
    /// </summary>
    public static class TimeTools
    {
        #region 计算年龄
        public static int GetAgeByBirth(this string birth)
        {
            if (string.IsNullOrEmpty(birth))
                birth = TimeNow().ToString();
            DateTime birthdate = Convert.ToDateTime(birth);
            DateTime now = DateTime.Now;
            int age = now.Year - birthdate.Year;
            if (now.Month < birthdate.Month || (now.Month == birthdate.Month && now.Day < birthdate.Day))
            {
                age--;
            }
            return age < 0 ? 0 : age;
        }
        #endregion
        #region 获取系统当前时间的几个方法（返回时间+格式化后的时间字符串）

        public static TimeSpan TimeSpanDiff(string DateTime1, string DateTime2)
        {
            TimeSpan ts = Convert.ToDateTime(DateTime2) - Convert.ToDateTime(DateTime1);
            return ts;
        }

        public static DateTime ToTime(this string time)
        {
            return Convert.ToDateTime(time);
        }
        /// <summary>
        /// 获取系统当前时间
        /// </summary>
        /// <returns>系统当前时间</returns>
        public static DateTime TimeNow()
        {
            Instant now = SystemClock.Instance.GetCurrentInstant();
            var shanghaiZone = DateTimeZoneProviders.Tzdb["Asia/Shanghai"];
            return now.InZone(shanghaiZone).ToDateTimeUnspecified();
        }
        /// <summary>
        /// 获取系统当前时间格式化字符串 24小时制 被格式化为 (yyyy-MM-dd HH:mm:ss.fff)
        /// </summary>
        /// <returns>系统当前格式化的时间字符串(yyyy-MM-dd HH:mm:ss.fff)</returns>
        public static string TimeNowStringYMD24HMSF()
        {
            return TimeNow().ToStringYMD24HMSF();
        }

        /// <summary>
        /// 获取系统当前时间格式化字符串 12小时制 被格式化为 (yyyy-MM-dd hh:mm:ss.fff)
        /// </summary>
        /// <returns>系统当前格式化的时间字符串(yyyy-MM-dd hh:mm:ss.fff)</returns>
        public static string TimeNowStringYMD12HMSF(this DateTime time)
        {
            return TimeNow().ToStringYMD12HMSF();
        }

        /// <summary>
        /// 获取系统当前时间格式化字符串 24小时制 被格式化为 (yyyy-MM-dd HH:mm:ss)
        /// </summary>
        /// <returns>系统当前格式化的时间字符串(yyyy-MM-dd HH:mm:ss)</returns>
        public static string TimeNowStringYMD24HMS(this DateTime time)
        {
            return TimeNow().ToStringYMD24HMS();
        }

        /// <summary>
        /// 获取系统当前时间格式化字符串 12小时制 被格式化为 (yyyy-MM-dd hh:mm:ss)
        /// </summary>
        /// <returns>系统当前格式化的时间字符串(yyyy-MM-dd hh:mm:ss)</returns>
        public static string TimeNowStringYMD12HMS(this DateTime time)
        {
            return TimeNow().ToStringYMD12HMS();
        }

        /// <summary>
        /// 获取系统当前时间格式化字符串  被格式化为 (yyyy-MM-dd)
        /// </summary>
        /// <returns>系统当前格式化的时间字符串(yyyy-MM-dd)</returns>
        public static string TimeNowStringYMD(this DateTime time)
        {
            return TimeNow().ToStringYMD();
        }

        #endregion

        #region DateTime 扩展几个 格式方法

        /// <summary>
        /// 时间 格式化 24小时制 被格式化为  (yyyy-MM-dd HH:mm:ss.fff)
        /// </summary>
        /// <param name="time">被格式的时间</param>
        /// <returns>格式化后的时间字符串(yyyy-MM-dd HH:mm:ss.fff)</returns>
        public static string ToStringYMD24HMSF(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        /// <summary>
        /// 时间 格式化 12小时制 被格式化为  (yyyy-MM-dd hh:mm:ss.fff)
        /// </summary>
        /// <param name="time">被格式化时间</param>
        /// <returns>格式化后的时间字符串(yyyy-MM-dd hh:mm:ss.fff)</returns>
        public static string ToStringYMD12HMSF(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd hh:mm:ss.fff");
        }

        /// <summary>
        /// 时间 格式化 24小时制 被格式化为  (yyyy-MM-dd HH:mm:ss)
        /// </summary>
        /// <param name="time">被格式化时间</param>
        /// <returns>格式化后的时间字符串(yyyy-MM-dd HH:mm:ss)</returns>
        public static string ToStringYMD24HMS(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 时间 格式化 12小时制 被格式化为  (yyyy-MM-dd hh:mm:ss)
        /// </summary>
        /// <param name="time">被格式化时间</param>
        /// <returns>格式化后的时间字符串(yyyy-MM-dd hh:mm:ss)</returns>
        public static string ToStringYMD12HMS(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd hh:mm:ss");
        }

        /// <summary>
        /// 时间 格式化  被格式化为  (yyyy-MM-dd)
        /// </summary>
        /// <param name="time">被格式化时间</param>
        /// <returns>格式化后的时间字符串(yyyy-MM-dd)</returns>
        public static string ToStringYMD(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd");
        }

        #endregion

        #region 获取时间戳

        /// <summary>
        /// 获取时间戳(秒)
        /// </summary>
        /// <returns>秒时间戳</returns>
        public static long GetSecondTimestamp()
        {
            // 以1970-1-1 为时间开始 同系统当前时间的秒差值即为秒时间戳
            TimeSpan ts = TimeNow() - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// 获取时间戳（毫秒）
        /// </summary>
        /// <returns>毫秒时间戳</returns>
        public static long GetMilliSecondTimestamp()
        {
            // 以1970-1-1 为时间开始 同系统当前时间的毫秒差值即为毫秒时间戳
            TimeSpan ts = TimeNow() - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds);
        }

        #endregion

        #region 将一个时间戳转换为一个时间

        /// <summary>
        /// 将一个秒时间戳转换为时间格式(秒)
        /// </summary>
        /// <param name="secondTimestamp">秒时间戳</param>
        /// <returns>转换后的时间</returns>
        public static DateTime? SecondStampToDateTime(long secondTimestamp)
        {
            //  做一个简单的判断
            if (secondTimestamp <= 0)
            {
                return null;
            }

            // 以1970-1-1 为时间开始，通过计算与之的时间差，来计算其对应的时间
            DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(secondTimestamp).ToLocalTime();
            return dateTime;
        }

        /// <summary>
        /// 将一个字符串秒时间戳转换为时间格式(秒)
        /// </summary>
        /// <param name="secondTimestampStr">字符串秒时间戳</param>
        /// <returns>转换后的时间</returns>
        public static DateTime? SecondStampToDateTime(string secondTimestampStr)
        {
            // 如果为空，那么直接返回null
            if (string.IsNullOrEmpty(secondTimestampStr))
            {
                return null;
            }

            // 首先将字符串时间戳转换为数字
            long secondTimestamp = 0;
            long.TryParse(secondTimestampStr, out secondTimestamp);

            // 调用
            return SecondStampToDateTime(secondTimestamp);
        }

        /// <summary>
        /// 将一个字符串毫秒时间戳转换为时间格式(毫秒)
        /// </summary>
        /// <param name="secondTimestampStr">字符串毫秒时间戳</param>
        /// <returns>转换后的时间</returns>
        public static DateTime? MilliSecondStampToDateTime(long secondTimestamp)
        {
            //  做一个简单的判断
            if (secondTimestamp <= 0)
            {
                return null;
            }

            // 以1970-1-1 为时间开始，通过计算与之的时间差，来计算其对应的时间
            DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddMilliseconds(secondTimestamp).ToLocalTime();

            return dateTime;
        }

        /// <summary>
        /// 将一个毫秒时间戳转换为时间格式(毫秒)
        /// </summary>
        /// <param name="milliSecondStampStr">毫秒时间戳</param>
        /// <returns>转换后的时间</returns>
        public static DateTime? MilliSecondStampToDateTime(string milliSecondStampStr)
        {
            // 如果为空，那么直接返回null
            if (string.IsNullOrEmpty(milliSecondStampStr))
            {
                return null;
            }

            // 首先将字符串时间戳转换为数字
            long milliSecondStamp = 0;
            long.TryParse(milliSecondStampStr, out milliSecondStamp);

            // 调用
            return MilliSecondStampToDateTime(milliSecondStamp);
        }

        #endregion
    }

    //public class DateFormatter
    //{
    //    使用C#把发表的时间改为几个月,几天前,几小时前,几分钟前,或几秒前
    //    2008年03月15日 星期六 02:35
    //    public static string DateStringFromNow(DateTime dt)
    //    {
    //        TimeSpan span = DateTime.Now - dt;
    //        if (span.TotalDays > 60)
    //        {
    //            return dt.ToShortDateString();
    //        }
    //        else
    //        {
    //            if (span.TotalDays > 30)
    //            {
    //                return
    //                "1个月前";
    //            }
    //            else
    //            {
    //                if (span.TotalDays > 14)
    //                {
    //                    return
    //                    "2周前";
    //                }
    //                else
    //                {
    //                    if (span.TotalDays > 7)
    //                    {
    //                        return
    //                        "1周前";
    //                    }
    //                    else
    //                    {
    //                        if (span.TotalDays > 1)
    //                        {
    //                            return
    //                            string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
    //                        }
    //                        else
    //                        {
    //                            if (span.TotalHours > 1)
    //                            {
    //                                return
    //                                string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
    //                            }
    //                            else
    //                            {
    //                                if (span.TotalMinutes > 1)
    //                                {
    //                                    return
    //                                    string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
    //                                }
    //                                else
    //                                {
    //                                    if (span.TotalSeconds >= 1)
    //                                    {
    //                                        return
    //                                        string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
    //                                    }
    //                                    else
    //                                    {
    //                                        return
    //                                        "1秒前";
    //                                    }
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    C#中使用TimeSpan计算两个时间的差值
    //    可以反加两个日期之间任何一个时间单位。
    //    public static string DateDiff(DateTime DateTime1, DateTime DateTime2)
    //    {
    //        string dateDiff = null;

    //        TimeSpan ts = DateTime1 - DateTime2;

    //        if (ts.Days > 0)
    //            dateDiff += ts.Days.ToString() + "天";
    //        if (ts.Hours > 0)
    //            dateDiff += ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
    //        dateDiff += ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
    //        return dateDiff;
    //    }
    //    public static int SecondsDiff(DateTime DateTime1, DateTime DateTime2)
    //    {
    //        TimeSpan ts = DateTime1 - DateTime2;
    //        return Convert.ToInt32(ts.TotalSeconds);
    //    }

    //    public static TimeSpan TimeSpanDiff(DateTime DateTime1, DateTime DateTime2)
    //    {
    //        TimeSpan ts = DateTime2 - DateTime1;
    //        return ts;
    //    }
    //    说明：
    //    /**/
    //    /*1.DateTime值类型代表了一个从公元0001年1月1日0点0分0秒到公元9999年12月31日23点59分59秒之间的具体日期时刻。因此，你可以用DateTime值类型来描述任何在想象范围之内的时间。一个DateTime值代表了一个具体的时刻
    //    2.TimeSpan值包含了许多属性与方法，用于访问或处理一个TimeSpan值
    //    下面的列表涵盖了其中的一部分：
    //    Add：与另一个TimeSpan值相加。 
    //    Days:返回用天数计算的TimeSpan值。 
    //    Duration:获取TimeSpan的绝对值。 
    //    Hours:返回用小时计算的TimeSpan值 
    //    Milliseconds:返回用毫秒计算的TimeSpan值。 
    //    Minutes:返回用分钟计算的TimeSpan值。 
    //    Negate:返回当前实例的相反数。 
    //    Seconds:返回用秒计算的TimeSpan值。 
    //    Subtract:从中减去另一个TimeSpan值。 
    //    Ticks:返回TimeSpan值的tick数。 
    //    TotalDays:返回TimeSpan值表示的天数。 
    //    TotalHours:返回TimeSpan值表示的小时数。 
    //    TotalMilliseconds:返回TimeSpan值表示的毫秒数。 
    //    TotalMinutes:返回TimeSpan值表示的分钟数。 
    //    TotalSeconds:返回TimeSpan值表示的秒数。
    //    */

    //    /**/
    //    / <summary>
    //    / 日期比较
    //    / </summary>
    //    / <param name = "today" > 当前日期 </ param >
    //    / < param name="writeDate">输入日期</param>
    //    / <param name = "n" > 比较天数 </ param >
    //    / < returns > 大于天数返回true，小于返回false</returns>
    //    private static bool CompareDate(string today, string writeDate, int n)
    //    {
    //        DateTime Today = Convert.ToDateTime(today);
    //        DateTime WriteDate = Convert.ToDateTime(writeDate);
    //        WriteDate = WriteDate.AddDays(n);
    //        if (Today >= WriteDate)
    //            return false;
    //        else
    //            return true;
    //    }
    //}
}
