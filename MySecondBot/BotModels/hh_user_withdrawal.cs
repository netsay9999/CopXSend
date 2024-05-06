using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace H.Bot.BotModels
{
    ///<summary>
    ///提现记录
    ///</summary>
    [SugarTable("hh_user_withdrawal")]
    public partial class hh_user_withdrawal
    {
           public hh_user_withdrawal(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int id {get;set;}

           /// <summary>
           /// Desc:用户ID
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? userid {get;set;}

           /// <summary>
           /// Desc:类型（1：绿色积分提现；2：A积分提现；3：B积分提现）
           /// Default:true
           /// Nullable:True
           /// </summary>           
           public bool? typename {get;set;}

           /// <summary>
           /// Desc:提现总金额
           /// Default:0.00
           /// Nullable:True
           /// </summary>           
           public decimal? totalmoney {get;set;}

           /// <summary>
           /// Desc:平台手续费
           /// Default:0.00
           /// Nullable:True
           /// </summary>           
           public decimal? commission {get;set;}

           /// <summary>
           /// Desc:实际到账金额
           /// Default:0.00
           /// Nullable:True
           /// </summary>           
           public decimal? money {get;set;}

           /// <summary>
           /// Desc:说明
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string description {get;set;}

           /// <summary>
           /// Desc:0：待审核；1：通过；2：拒绝； 3:取消
           /// Default:true
           /// Nullable:True
           /// </summary>           
           public bool? ischeck {get;set;}

           /// <summary>
           /// Desc:说明
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string checknote {get;set;}

           /// <summary>
           /// Desc:审核时间
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? checktime {get;set;}

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
           /// Desc:类型（0：储蓄卡；1：支付宝；2：微信; 3: 交易所）
           /// Default:true
           /// Nullable:True
           /// </summary>           
           public bool? typeid {get;set;}

           /// <summary>
           /// Desc:绑定交易所账号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string jysno {get;set;}

           /// <summary>
           /// Desc:真实姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string username {get;set;}

           /// <summary>
           /// Desc:账户号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string bankno {get;set;}

           /// <summary>
           /// Desc:银行名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string bankname {get;set;}

           /// <summary>
           /// Desc:开户行
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string bankcode {get;set;}

           /// <summary>
           /// Desc:支付类型（0：未操作；1：汇聚代付支付; 2:后台手动支付）
           /// Default:true
           /// Nullable:True
           /// </summary>           
           public bool? paytype {get;set;}

           /// <summary>
           /// Desc:支付状态（0：未支付；1：已支付）
           /// Default:true
           /// Nullable:True
           /// </summary>           
           public bool? paystatus {get;set;}

           /// <summary>
           /// Desc:支付回调订单号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string payorderno {get;set;}

           /// <summary>
           /// Desc:支付时间
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? paytime {get;set;}

    }
}
