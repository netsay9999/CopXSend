using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace H.Bot.BotModels
{
    ///<summary>
    ///角色列表
    ///</summary>
    [SugarTable("hh_admin_role")]
    public partial class hh_admin_role
    {
           public hh_admin_role(){


           }
           /// <summary>
           /// Desc:角色ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public short id {get;set;}

           /// <summary>
           /// Desc:角色名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string name {get;set;}

           /// <summary>
           /// Desc:权限列表
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string menulist {get;set;}

           /// <summary>
           /// Desc:角色描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string description {get;set;}

           /// <summary>
           /// Desc:1：删除
           /// Default:true
           /// Nullable:True
           /// </summary>           
           public bool? status {get;set;}

           /// <summary>
           /// Desc:添加时间
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? addtime {get;set;}

    }
}
