using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace H.Bot.BotModels
{
    ///<summary>
    ///文章分类表
    ///</summary>
    [SugarTable("hh_article_category")]
    public partial class hh_article_category
    {
           public hh_article_category(){


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
           /// Desc:展示图
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string thumb {get;set;}

           /// <summary>
           /// Desc:关键词
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string keywords {get;set;}

           /// <summary>
           /// Desc:简介
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string description {get;set;}

           /// <summary>
           /// Desc:点击量
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? readnum {get;set;}

           /// <summary>
           /// Desc:排序
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? listorder {get;set;}

           /// <summary>
           /// Desc:0：隐藏；1：显示
           /// Default:true
           /// Nullable:True
           /// </summary>           
           public bool? isshow {get;set;}

           /// <summary>
           /// Desc:0：正常；1：删除
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

           /// <summary>
           /// Desc:修改时间
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? updatetime {get;set;}

           /// <summary>
           /// Desc:版本号
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? version {get;set;}

    }
}
