using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace H.Bot.BotModels
{
    ///<summary>
    ///短信记录
    ///</summary>
    [SugarTable("hh_smscode")]
    public partial class hh_smscode
    {
           public hh_smscode(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int id {get;set;}

           /// <summary>
           /// Desc:类型（0：注册验证码；1：修改密码验证码）
           /// Default:true
           /// Nullable:True
           /// </summary>           
           public bool? typeid {get;set;}

           /// <summary>
           /// Desc:手机号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mobile {get;set;}

           /// <summary>
           /// Desc:验证码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string smscode {get;set;}

           /// <summary>
           /// Desc:短信内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string content {get;set;}

           /// <summary>
           /// Desc:发送短信ip
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string smsip {get;set;}

           /// <summary>
           /// Desc:删除（0：正常；1：删除）
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
