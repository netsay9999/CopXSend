using H.RedisTools;
using H.Saas.Tools;
using Microsoft.Extensions.Configuration;
using SqlSugar;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;


namespace MySecondBot
{
    public class BaseBll : DbContext
    {
        public ApiResultEntity Success(string msg = "操作成功", object data = null, int code = 0)
        {
            return new ApiResultEntity
            {
                msg = msg,
                data = data,
                error = code,
                success = code == 0 ? true : false,
            };
        }
        public ApiResultEntity Success(bool b, object data = null)
        {
            return Success(b ? "操作成功" : "操作失败", data, b ? 0 : -1);
        }
        public ApiResultEntity Errors(string msg = "操作失败", int code = -1)
        {
            return Success(msg, null, code);
        }



        public static string Post(string parameterData, string serviceUrl, string ContentType = "application/json;charset= utf-8")
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);

            byte[] buf = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(parameterData);
            myRequest.Method = "POST";
            myRequest.ContentType = ContentType;
            myRequest.ContentLength = buf.Length;
            myRequest.MaximumAutomaticRedirections = 1;
            myRequest.AllowAutoRedirect = true;
            Stream stream = myRequest.GetRequestStream();
            stream.Write(buf, 0, buf.Length);
            stream.Close();
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string returnData = reader.ReadToEnd();
            reader.Close();
            myResponse.Close();
            return returnData;
        }


        #region 常用生成 例如时间戳 主键等。
        /// <summary>
        /// 主键ID生成
        /// </summary>
        public static string Identity
        {
            get
            {
                var guid = Guid.NewGuid().ToString().Replace("-", "");
                var guid8 = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
                return $"0x{guid}{guid8}";
            }
        }
        public string AutoNo
        {
            get
            {
                return TimeNow.ToString("yyMMddHHmm") + new Random(GetRandomSeed).Next(999, 9999).ToString();
            }
        }
        /// <summary>
        /// 自动编号
        /// </summary>
        public string AutoCode
        {
            get
            {
                return new Random(GetRandomSeed).Next(999, 9999).ToString();
            }
        }
        public static string AutoNum(int min, int max)
        {
            return new Random(GetRandomSeed).Next(min, max).ToString();
        }
        public decimal AutoRandom(int min, int max)
        {
            return new Random(GetRandomSeed).Next(min, max);
        }
        public int AutoIntRandom(int min, int max)
        {
            return new Random(GetRandomSeed).Next(min, max);
        }
        public int AutoIntCode
        {
            get
            {
                return new Random(GetRandomSeed).Next(999, 9999);
            }
        }
        public static int GetRandomSeed
        {
            get
            {
                byte[] bytes = new byte[4];
                System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
                rng.GetBytes(bytes);
                return BitConverter.ToInt32(bytes, 0);
            }
        }
        /// <summary>
        /// 系统时间
        /// </summary>
        public DateTime TimeNow
        {
            get
            {
                return DateTime.Now;
            }
        }
        /// <summary>
        /// 当天时间戳
        /// </summary>
        public int DayTicks
        {
            get
            {
                return TimeNow.ToString("yyyy-MM-dd").ToIntTimeStamp();
            }
        }
        public int MonthTicks
        {
            get
            {
                return TimeNow.ToString("yyyy-MM-01").ToIntTimeStamp();
            }
        }


        /// <summary>
        /// 时间戳
        /// </summary>
        public int TimeTicks
        {
            get
            {
                return TimeHelper.GetCurrentIntTimestamp(false);
            }
        }
        public bool IsNumeric(string str)
        {
            Regex reg1 = new Regex(@"^[0-9]\d*$");
            return reg1.IsMatch(str);
        }
        public bool IsPhone(string input)
        {
            Regex regex = new Regex("^[1][3-9]+\\d{9}");
            return regex.IsMatch(input);

        }
        #endregion
    }

    public class DbContext
    {
        public static string token = Configs.Configuration.GetConnectionString("token");
        public static ulong channelId = (ulong)Int64.Parse(Configs.Configuration.GetConnectionString("channelId"));
        public static string apihost = Configs.Configuration.GetConnectionString("apihost");
        public static decimal chat_points = Configs.Configuration.GetConnectionString("chat_points").NumX(2) ?? 0;

        public static string smtpHost = Configs.Configuration.GetConnectionString("mail_Host");
        public static int smtpPort = Configs.Configuration.GetConnectionString("mail_Port").toInt() ?? 587;
        public static string smtpPassword = Configs.Configuration.GetConnectionString("mail_Password");
        public static string mail_AppName = Configs.Configuration.GetConnectionString("mail_AppName");
        public static string senderAddress = Configs.Configuration.GetConnectionString("mail_From");

        public static RedisHelper redis = new RedisHelper(0);

        public SqlSugarClient dbContent;
        public DbContext()
        {
            var connStr = Configs.Configuration.GetConnectionString("mysql");
            if (string.IsNullOrEmpty(connStr))
                connStr = Configs.Configuration.GetConnectionString("mysqlStr");
            dbContent = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connStr,
                DbType = DbType.MySql,//设置数据库类型
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute,
            });
        }
    }
}
