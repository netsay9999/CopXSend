using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace H.Saas.Tools
{
    public static partial class Extensions
    {

        public static string SpecialCode(this string s)
        {
            if (s == null)
                return "";
            s = s.Replace(@"\", "");
            s = Regex.Replace(s, "[ \\[ \\] \\^ \\-_*×――(^)$%~!/@#$…&%￥—+=<>《》|!！??？:：•`·、。，；,.;\"‘’“”-]", "").ToUpper();
            return s.filterEmoji();

        }

        public static string filterEmoji(this string str)
        {

            string origin = str;
            try
            {
                //关键代码
                foreach (var a in str)
                {
                    byte[] bts = Encoding.UTF32.GetBytes(a.ToString());
                    if (bts[0].ToString() == "253" && bts[1].ToString() == "255")
                    {
                        str = str.Replace(a.ToString(), "");
                    }
                }
            }
            catch (Exception)
            {
                str = origin;
            }
            return str;
        }

        /// <summary>
        /// 判读是否是数字
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNumber(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            const string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            return rx.IsMatch(input);
        }

        /// <summary>
        /// 首字母小写写
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FirstCharToLower(this string input)
        {
            if (String.IsNullOrEmpty(input))
                return input;
            string str = input.First().ToString().ToLower() + input.Substring(1);
            return str;
        }

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FirstCharToUpper(this string input)
        {
            if (String.IsNullOrEmpty(input))
                return input;
            string str = input.First().ToString().ToUpper() + input.Substring(1);
            return str;
        }
    }
}
