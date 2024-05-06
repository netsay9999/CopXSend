using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace H.Bot.BotModels
{
    ///<summary>
    ///后台管理员登录记录表
    ///</summary>
    [SugarTable("hh_admin_log")]
    public partial class hh_admin_log
    {
           public hh_admin_log(){


           }
           /// <summary>
           /// Desc:表id
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:管理员id
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? adminid {get;set;}

           /// <summary>
           /// Desc:日志描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string loginfo {get;set;}

           /// <summary>
           /// Desc:ip地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string logip {get;set;}

           /// <summary>
           /// Desc:日志时间
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? logtime {get;set;}

    }
}
