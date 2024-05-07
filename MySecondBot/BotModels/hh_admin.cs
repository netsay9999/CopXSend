using SqlSugar;

namespace H.Bot.BotModels
{
    ///<summary>
    ///后台管理员
    ///</summary>
    [SugarTable("hh_admin")]
    public partial class hh_admin
    {
        public hh_admin()
        {


        }
        /// <summary>
        /// Desc:用户id
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public short id { get; set; }

        /// <summary>
        /// Desc:角色id
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public short? roleid { get; set; }

        /// <summary>
        /// Desc:用户名
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string username { get; set; }

        /// <summary>
        /// Desc:电话
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string mobile { get; set; }

        /// <summary>
        /// Desc:密码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string password { get; set; }

        /// <summary>
        /// Desc:最后登录时间
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? lastlogin { get; set; }

        /// <summary>
        /// Desc:最后登录ip
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string lastip { get; set; }

        /// <summary>
        /// Desc:1：删除
        /// Default:true
        /// Nullable:True
        /// </summary>           
        public bool? status { get; set; }

        /// <summary>
        /// Desc:添加时间
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? addtime { get; set; }

    }
}
