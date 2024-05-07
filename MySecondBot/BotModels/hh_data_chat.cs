using SqlSugar;

namespace H.Bot.BotModels
{
    ///<summary>
    ///用户  chat  记录表
    ///</summary>
    [SugarTable("hh_data_chat")]
    public partial class hh_data_chat
    {
        public hh_data_chat()
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
        /// Desc:用户ID
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? userid { get; set; }

        /// <summary>
        /// Desc:收支状态（0：收入；1：支出）
        /// Default:true
        /// Nullable:True
        /// </summary>           
        public bool? incometype { get; set; }

        /// <summary>
        /// Desc:chat
        /// Default:0.00
        /// Nullable:True
        /// </summary>           
        public decimal? chat { get; set; }

        /// <summary>
        /// Desc:类型
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? changeid { get; set; }

        /// <summary>
        /// Desc:说明
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string description { get; set; }

        /// <summary>
        /// Desc:来源订单ID
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? sourceid { get; set; }

        /// <summary>
        /// Desc:来源用户ID
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? sourceuserid { get; set; }

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
