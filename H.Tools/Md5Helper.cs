using System;
using System.Security.Cryptography;
using System.Text;

namespace H.Saas.Tools
{
    public class Md5Helper
    {
        public static string MdEncrypt(string str, int key = 32)
        {
            if (key == 32)
                return Encrypt32(str);
            else
                return Encrypt16(str);
        }
        public static string Encrypt(string str, int key = 32)
        {
            str = "hhTP" + str;
            if (key == 32)
                return Encrypt32(str);
            else
                return Encrypt16(str);
        }
        /// <summary>
        /// 此代码示例通过创建哈希字符串适用于任何 MD5 哈希函数 （在任何平台） 上创建 32 个字符的十六进制格式哈希字符串
        /// 官网案例改编
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string Encrypt32(string str)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(str));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                string hash = sBuilder.ToString();
                return hash;
            }
        }
        /// <summary>
        /// 获取16位md5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string Encrypt16(string str)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(str));
                //转换成字符串，并取9到25位
                string sBuilder = BitConverter.ToString(data, 4, 8);
                //BitConverter转换出来的字符串会在每个字符中间产生一个分隔符，需要去除掉
                sBuilder = sBuilder.Replace("-", "");
                return sBuilder.ToString();
            }
        }

    }
}