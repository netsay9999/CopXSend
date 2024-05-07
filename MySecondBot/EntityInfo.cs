namespace MySecondBot
{
    public class EntityInfo
    {
    }
    public class ApiResultEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int error { get; set; }
        /// <summary>
        /// 邀请码不存在
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object data { get; set; }
        public bool success { get; set; }
    }


    public class Point_Data
    {

    }

    public class User_Info
    {
        public string email { get; set; }
        public string nickname { get; set; }
        public string usercode { get; set; }
        public string usdt { get; set; }
        public string copx { get; set; }
        public string chat { get; set; }
        public int userid { get; set; }
    }
}
