using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace H.Bot.BotModels
{
    ///<summary>
    ///配置表
    ///</summary>
    [SugarTable("hh_config")]
    public partial class hh_config
    {
           public hh_config(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int id {get;set;}

           /// <summary>
           /// Desc:名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string name {get;set;}

           /// <summary>
           /// Desc:内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string value {get;set;}

    }
}
