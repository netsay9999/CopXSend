using SqlSugar;

namespace H.Bot.BotModels
{
    ///<summary>
    ///用户 copx 互转
    ///</summary>
    [SugarTable("hh_to_copx_copx")]
    public partial class hh_to_copx_copx
    {
        public hh_to_copx_copx()
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
        /// Desc:转出人 用户ID 
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? userid { get; set; }

        /// <summary>
        /// Desc:转出 copx
        /// Default:0.000000
        /// Nullable:True
        /// </summary>           
        public decimal? copx { get; set; }

        /// <summary>
        /// Desc:转入人 用户ID 
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? otheruserid { get; set; }

        /// <summary>
        /// Desc:转入 copx
        /// Default:0.000000
        /// Nullable:True
        /// </summary>           
        public decimal? othercopx { get; set; }

        /// <summary>
        /// Desc:0：正常；1：删除
        /// Default:true
        /// Nullable:True
        /// </summary>           
        public bool? status { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? addtime { get; set; }

    }
}
