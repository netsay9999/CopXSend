using SqlSugar;

namespace H.Bot.BotModels
{
    ///<summary>
    ///后台菜单栏目表
    ///</summary>
    [SugarTable("hh_admin_menu")]
    public partial class hh_admin_menu
    {
        public hh_admin_menu()
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
        /// Desc:平台（0：超管平台；1：商家平台）
        /// Default:true
        /// Nullable:True
        /// </summary>           
        public bool? platform { get; set; }

        /// <summary>
        /// Desc:上级模块ID  0表示顶级模块 
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? pid { get; set; }

        /// <summary>
        /// Desc:名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string name { get; set; }

        /// <summary>
        /// Desc:控制器
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string controller { get; set; }

        /// <summary>
        /// Desc:动作
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string action { get; set; }

        /// <summary>
        /// Desc:icon图标
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string iconimg { get; set; }

        /// <summary>
        /// Desc:按钮代码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string button { get; set; }

        /// <summary>
        /// Desc:按钮位置（1：表格头部；2：数据栏）
        /// Default:true
        /// Nullable:True
        /// </summary>           
        public bool? position { get; set; }

        /// <summary>
        /// Desc:0：隐藏；1：显示
        /// Default:true
        /// Nullable:True
        /// </summary>           
        public bool? isshow { get; set; }

        /// <summary>
        /// Desc:排序（值越大越靠前）
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? listorder { get; set; }

        /// <summary>
        /// Desc:删除状态（0：正常；1：删除）
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
