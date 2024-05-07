using SqlSugar;

namespace H.Bot.BotModels
{
    ///<summary>
    ///用户表
    ///</summary>
    [SugarTable("hh_user_copy1")]
    public partial class hh_user_copy1
    {
        public hh_user_copy1()
        {


        }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }

        /// <summary>
        /// Desc:0：未知；1：前端注册用户；2：discord授权用户
        /// Default:true
        /// Nullable:True
        /// </summary>           
        public bool? usertype { get; set; }

        /// <summary>
        /// Desc:邀请码，随机
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string usercode { get; set; }

        /// <summary>
        /// Desc:登录账号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string username { get; set; }

        /// <summary>
        /// Desc:邮箱
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string email { get; set; }

        /// <summary>
        /// Desc:昵称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string nickname { get; set; }

        /// <summary>
        /// Desc:头像
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string headimg { get; set; }

        /// <summary>
        /// Desc:密码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string password { get; set; }

        /// <summary>
        /// Desc:支付密码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string paypassword { get; set; }

        /// <summary>
        /// Desc:usdt地址
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string address { get; set; }

        /// <summary>
        /// Desc:0：未知；1：男；2：女
        /// Default:true
        /// Nullable:True
        /// </summary>           
        public bool? sex { get; set; }

        /// <summary>
        /// Desc:生日
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string birthday { get; set; }

        /// <summary>
        /// Desc:QQ
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string qq { get; set; }

        /// <summary>
        /// Desc:购物积分
        /// Default:0.000000
        /// Nullable:True
        /// </summary>           
        public decimal? usdt { get; set; }

        /// <summary>
        /// Desc:增值积分 
        /// Default:0.000000
        /// Nullable:True
        /// </summary>           
        public decimal? copx { get; set; }

        /// <summary>
        /// Desc:绿色积分
        /// Default:0.000000
        /// Nullable:True
        /// </summary>           
        public decimal? chat { get; set; }

        /// <summary>
        /// Desc:group等级
        /// Default:1
        /// Nullable:True
        /// </summary>           
        public int? grouplevelid { get; set; }

        /// <summary>
        /// Desc:类别 group node platform
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? teamlevelid { get; set; }

        /// <summary>
        /// Desc:直推上级用户ID
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? firstleader { get; set; }

        /// <summary>
        /// Desc:间推上级用户ID
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? secondleader { get; set; }

        /// <summary>
        /// Desc:三级用户ID
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? thirdleader { get; set; }

        /// <summary>
        /// Desc:所有父级ids
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string fids { get; set; }

        /// <summary>
        /// Desc:group id
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? groupid { get; set; }

        /// <summary>
        /// Desc:node id
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? nodeid { get; set; }

        /// <summary>
        /// Desc:推荐层级 级别
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? level { get; set; }

        /// <summary>
        /// Desc:直推人数
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? invitenum { get; set; }

        /// <summary>
        /// Desc:直推团队人数
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? teamnum { get; set; }

        /// <summary>
        /// Desc:自己报单金额
        /// Default:0.00
        /// Nullable:True
        /// </summary>           
        public decimal? mymoney { get; set; }

        /// <summary>
        /// Desc:团队用户报单金额
        /// Default:0.00
        /// Nullable:True
        /// </summary>           
        public decimal? teammoney { get; set; }

        /// <summary>
        /// Desc:30天交易有效人数
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? dealnum { get; set; }

        /// <summary>
        /// Desc:30天新增加交易有效人数
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? dealnewnum { get; set; }

        /// <summary>
        /// Desc:第三方凭证
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string openid { get; set; }

        /// <summary>
        /// Desc:登录凭证
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string token { get; set; }

        /// <summary>
        /// Desc:提现 0：不可提现；1：可提现
        /// Default:true
        /// Nullable:True
        /// </summary>           
        public bool? iswithdrawal { get; set; }

        /// <summary>
        /// Desc:0：正常；1：锁定
        /// Default:true
        /// Nullable:True
        /// </summary>           
        public bool? islock { get; set; }

        /// <summary>
        /// Desc:0：未绑定；1：已绑定
        /// Default:true
        /// Nullable:True
        /// </summary>           
        public bool? bindBinance { get; set; }

        /// <summary>
        /// Desc:0：未绑定；1：已绑定
        /// Default:true
        /// Nullable:True
        /// </summary>           
        public bool? bindOkx { get; set; }

        /// <summary>
        /// Desc:0：未绑定；1：已绑定
        /// Default:true
        /// Nullable:True
        /// </summary>           
        public bool? bindGate { get; set; }

        /// <summary>
        /// Desc:discord授权账户id
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string discord_id { get; set; }

        /// <summary>
        /// Desc:第三方discord用户信息
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string discord_json { get; set; }

        /// <summary>
        /// Desc:0：正常；1：删除
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

        /// <summary>
        /// Desc:更新时间
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? updatetime { get; set; }

    }
}
