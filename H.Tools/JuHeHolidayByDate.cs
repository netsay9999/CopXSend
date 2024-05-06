using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace H.Saas.Tools
{
    public class JuHeHolidayByDate
    {
        public JuHeHolidayEntity QueryJuHe(string date)
        {
            var result = "";
            int x = HttpGet($"http://apis.juhe.cn/fapig/calendar/day.php?date={date}&detail=1&key=00e8c48a45e582f1b09b9f29403b9c83", out result);
            if (x == 0)
            {
                return JsonConvert.DeserializeObject<JuHeHolidayEntity>(result);
            }
            return null;
        }

        private int HttpGet(string url, out string reslut)
        {
            reslut = "";
            try
            {
                HttpWebRequest wbRequest = (HttpWebRequest)WebRequest.Create(url);
                wbRequest.Proxy = null;
                wbRequest.Method = "GET";
                HttpWebResponse wbResponse = (HttpWebResponse)wbRequest.GetResponse();
                using (Stream responseStream = wbResponse.GetResponseStream())
                {
                    using (StreamReader sReader = new StreamReader(responseStream))
                    {
                        reslut = sReader.ReadToEnd();
                    }
                }
            }
            catch (Exception e)
            {
                reslut = e.Message;     //输出捕获到的异常，用OUT关键字输出
                return -1;              //出现异常，函数的返回值为-1
            }
            return 0;
        }

    }

    //如果好用，请收藏地址，帮忙分享。
    public class JuHeHolidayResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// 星期六
        /// </summary>
        public string week { get; set; }
        /// <summary>
        /// 节假日
        /// </summary>
        public string statusDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 虎
        /// </summary>
        public string animal { get; set; }
        /// <summary>
        /// 搬新房.动土.祈福.安葬.安门.修造.作灶.探病.掘井.上梁
        /// </summary>
        public string avoid { get; set; }
        /// <summary>
        /// 六
        /// </summary>
        public string cnDay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string day { get; set; }
        /// <summary>
        /// 己卯
        /// </summary>
        public string gzDate { get; set; }
        /// <summary>
        /// 癸丑
        /// </summary>
        public string gzMonth { get; set; }
        /// <summary>
        /// 壬寅
        /// </summary>
        public string gzYear { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isBigMonth { get; set; }
        /// <summary>
        /// 三十
        /// </summary>
        public string lDate { get; set; }
        /// <summary>
        /// 腊
        /// </summary>
        public string lMonth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lunarDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lunarMonth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lunarYear { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string month { get; set; }
        /// <summary>
        /// 结婚.合婚订婚.签订合同.交易.纳财.开业.安床.纳畜.打鱼.补垣.开池
        /// </summary>
        public string suit { get; set; }
        /// <summary>
        /// 除夕
        /// </summary>
        public string term { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string year { get; set; }
    }

    public class JuHeHolidayEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string reason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public JuHeHolidayResult result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int error_code { get; set; }
    }

}
