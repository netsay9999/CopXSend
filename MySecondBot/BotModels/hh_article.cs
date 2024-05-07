using SqlSugar;

namespace H.Bot.BotModels
{
    ///<summary>
    ///文章表
    ///</summary>
    [SugarTable("hh_article")]
    public partial class hh_article
    {
        public hh_article()
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
        /// Desc:分类ID
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? catid { get; set; }

        /// <summary>
        /// Desc:名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string name { get; set; }

        /// <summary>
        /// Desc:展示图
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string thumb { get; set; }

        /// <summary>
        /// Desc:关键词
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string keywords { get; set; }

        /// <summary>
        /// Desc:简介
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string description { get; set; }

        /// <summary>
        /// Desc:点击量
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? readnum { get; set; }

        /// <summary>
        /// Desc:详情
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string content { get; set; }

        /// <summary>
        /// Desc:排序（值越大越靠前）
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? listorder { get; set; }

        /// <summary>
        /// Desc:0：隐藏；1：显示
        /// Default:true
        /// Nullable:True
        /// </summary>           
        public bool? isshow { get; set; }

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

        /// <summary>
        /// Desc:版本号
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? version { get; set; }

    }
}
