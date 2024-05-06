using System;
using System.Text.RegularExpressions;

namespace H.Saas.Tools
{

    public class IDCard
    {

        /// <summary>
        /// 港澳居民来往内地通行证
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool isHKCard(string input)
        {
            Regex regex = new Regex("^([A-Z]\\d{6,10}(\\(\\w{1}\\))?)$");
            return regex.IsMatch(input);
        }
        /// <summary>
        /// 台湾居民来往大陆通行证
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool isTWCard(string input)
        {
            Regex regex = new Regex("^\\d{8}|^[a-zA-Z0-9]{10}|^\\d{18}$");
            return regex.IsMatch(input);
        }

        /// <summary>
        /// 军官证
        /// </summary>
        /// <param name="input">规则： 军/兵/士/文/职/广/（其余中文） + "字第" + 4到8位字母或数字 + "号"</param>
        /// <returns></returns>
        public static bool isOfficerCard(string input)
        {
            Regex regex = new Regex("^[\u4E00-\u9FA5](字第)([0-9a-zA-Z]{4,8})(号?)$");
            return regex.IsMatch(input);
        }
        /// <summary>
        /// /户口本
        /// </summary>
        /// <param name="input">规则： 15位数字, 18位数字, 17位数字 + X</param>
        /// <returns></returns>
        public static bool isAccountCard(string input)
        {
            Regex regex = new Regex("(^\\d{15}$)|(^\\d{18}$)|(^\\d{17}(\\d|X|x)$)");
            return regex.IsMatch(input);
        }
        /// <summary>
        /// 护照 
        /// </summary>
        /// <param name="input">规则： 14/15开头 + 7位数字, G + 8位数字, P + 7位数字, S/D + 7或8位数字,等</param>
        /// <returns></returns>
        public static bool isPassPortCard(string input)
        {
            Regex regex = new Regex("^([a-zA-z]|[0-9]){5,17}$");
            return regex.IsMatch(input);
        }

        /// <summary>
        /// 验证身份证合理性
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool CheckIDCard(string idNumber)
        {
            if (idNumber.Length == 18)
            {
                bool check = CheckIDCard18(idNumber);
                return check;
            }
            else if (idNumber.Length == 15)
            {
                bool check = CheckIDCard15(idNumber);
                return check;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 18位身份证号码验证
        /// </summary>
        private static bool CheckIDCard18(string idNumber)
        {
            long n = 0;
            if (long.TryParse(idNumber.Remove(17), out n) == false
            || n < Math.Pow(10, 16) || long.TryParse(idNumber.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(idNumber.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = idNumber.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = idNumber.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != idNumber.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }


        /// <summary>
        /// 16位身份证号码验证
        /// </summary>
        private static bool CheckIDCard15(string idNumber)
        {
            long n = 0;
            if (long.TryParse(idNumber, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(idNumber.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = idNumber.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;
        }
    }


}
