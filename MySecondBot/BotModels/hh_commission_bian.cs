using SqlSugar;

namespace H.Bot.BotModels
{
    ///<summary>
    ///用户 币安返佣  数据
    ///</summary>
    [SugarTable("hh_commission_bian")]
    public partial class hh_commission_bian
    {
        public hh_commission_bian()
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
        /// Desc:Order Type
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public string OrderType { get; set; }

        /// <summary>
        /// Desc:Friend's ID(Spot)
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? FriendID { get; set; }

        /// <summary>
        /// Desc:Friend's sub ID (Spot)
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? FriendsubID { get; set; }

        /// <summary>
        /// Desc:Commission Asset
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public string CommissionAsset { get; set; }

        /// <summary>
        /// Desc:Commission Earned
        /// Default:0.00000000
        /// Nullable:True
        /// </summary>           
        public decimal? CommissionEarned { get; set; }

        /// <summary>
        /// Desc:CommissionEarnedUSDT
        /// Default:0.00000000
        /// Nullable:True
        /// </summary>           
        public decimal? CommissionEarnedUSDT { get; set; }

        /// <summary>
        /// Desc:CommissionTime
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? CommissionTime { get; set; }

        /// <summary>
        /// Desc:Registration Time
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? RegistrationTime { get; set; }

        /// <summary>
        /// Desc:Referral ID
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? ReferralID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string note { get; set; }

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

    }
}
