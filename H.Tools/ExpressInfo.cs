using System.Collections.Generic;

namespace H.Saas.Tools
{
    public class ListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string time { get; set; }
        /// <summary>
        /// 【湖北省武汉市汉口金山公司】 派件中 派件人: 吴凤胜 电话 15342247436 如有疑问，请联系：19947575612
        /// </summary>
        public string status { get; set; }
    }

    public class Result
    {
        /// <summary>
        /// 
        /// </summary>
        public string number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 圆通速递
        /// </summary>
        public string typename { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string logo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ListItem> list { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int deliverystatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int issign { get; set; }
    }

    public class ExpressInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Result result { get; set; }
    }
}
