using Discord;
using Discord.WebSocket;
using H.Bot.BotModels;
using H.RedisTools;
using H.Saas.Tools;
using Newtonsoft.Json;
using OfficeOpenXml.Utils;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySecondBot
{
    public class Bot_Btn : BaseBll
    {
        public static UserBotBll bll = new UserBotBll();
        public async static Task Tjr(string keyId, SocketInteraction interaction)
        {
            var u = bll.GetUser(keyId);
            if (u == null)
            {
                await interaction.RespondAsync($"尚未授权", ephemeral: true);
            }
            else
            {
                if (u.firstleader == 0)
                {
                    var mb = new ModalBuilder()
                   .WithTitle("锁定推荐关系")
                   .WithCustomId("menu_tjr")
                   .AddTextInput("推荐码", "input_tjr", placeholder: "请输入推荐码");
                    await interaction.RespondWithModalAsync(mb.Build());
                }
                else
                {
                    await interaction.RespondAsync($":gem::你已經完成COPX绑定，尊敬的COPX會員!" +
                      $"\r\n:e_mail:你的copx信箱:{u.email};" +
                      $"\r\n:eyes:你的邀請碼 {u.usercode}。"
                      , ephemeral: true);
                }
                return;
            }
        }

        public static async Task UserCenter(string keyId, SocketInteraction interaction)
        {
            var u = bll.GetUser(keyId);
            if (u == null)
            {
                await interaction.RespondAsync($"你好，用户未授权!", ephemeral: true);
                return;
            }

            if (u.firstleader == 0)
            {
                await interaction.RespondAsync($"你好，{u.username}，用户未绑定推荐人!", ephemeral: true);
                return;
            }

            var msg =
                  $"\r\n:yum:你好，{u.username}" +
                  $"\r\n\r\n:id:COPX UID： {u.id}" +
                  $"\r\n\r\n::thumbsup::邀请人数： {u.invitenum}" +
                  $"\r\n\r\n:eyes:你的邀請碼： {u.usercode}" +
                  $"\r\n\r\n社区积分：{u.chat}" +
                  $"\r\n\r\nCopX：{u.copx}" +
                  $"\r\n\r\nUSDT：{u.usdt}\n\n\n";

            if (string.IsNullOrEmpty(u.fa_secret))
            {
                var cb = new ComponentBuilder()
                    .WithButton("绑定2FA", "btn_2FA", ButtonStyle.Success)
                    .WithButton("站内转账", "btn_zz", ButtonStyle.Danger)
                    .WithButton("COPX提现", "btn_tx", ButtonStyle.Danger)
                    .WithButton("绑定币安", "btn_bdba", ButtonStyle.Danger)
                    .WithButton("绑定OKX", "btn_bdokx", ButtonStyle.Danger)
                    .WithButton("绑定钱包", "btn_bdqb", ButtonStyle.Danger)
                    .WithButton("我的邀请", "btn_wdyq", ButtonStyle.Danger);
                await interaction.RespondAsync(msg,
                      components: cb.Build(),
                      ephemeral: true);
            }
            else
            {
                var cb = new ComponentBuilder()
                    .WithButton("绑定2FA", "btn_2FA", ButtonStyle.Success)
                    .WithButton("站内转账", "btn_zz", ButtonStyle.Success)
                    .WithButton("COPX提现", "btn_tx", ButtonStyle.Success)
                    .WithButton("绑定币安", "btn_bdba", ButtonStyle.Success)
                    .WithButton("绑定OKX", "btn_bdokx", ButtonStyle.Success)
                    .WithButton("绑定钱包", "btn_bdqb", ButtonStyle.Success)
                    .WithButton("我的邀请", "btn_wdyq", ButtonStyle.Success);
                await interaction.RespondAsync(msg,
                      components: cb.Build(),
                      ephemeral: true);
            }
            return;
        }

        public static async Task Bind_2FA(string keyId, SocketInteraction interaction)
        {
            var u = bll.GetUser(keyId);
            if (u == null)
            {
                await interaction.RespondAsync("未授权", ephemeral: true);
                return;
            }
            if (string.IsNullOrEmpty(u.fa_secret))
            {
                var guid = Identity;
                var gg = bll.Google(keyId, guid);
                redis.Set("fa_secret" + keyId, guid, 10, DType.Hours);
                var msg = $"\r\n:yum:你好，{u.username}，Google Authenticator ";
                msg += $"\r\n:eyes:账号：{gg.Account}";
                msg += $"\r\n:smiley:秘钥：{gg.ManualEntryKey}";
                msg += $"\r\n:smiley::smiley:请务必妥善保存。";

                var img = ImageHelper.SaveImg(gg.QrCodeSetupImageUrl, $"{guid}.png");

                var cb = new ComponentBuilder()
                      .WithButton("2FA二维码", "btn_2fa_qrcode", ButtonStyle.Success)
                     .WithButton("2FA校验", "btn_2fa_fa_secret", ButtonStyle.Success);

                await interaction.RespondAsync(msg,
                      components: cb.Build(),
                      ephemeral: true);

            }
            return;
        }

        public static async Task Bind_2FA_QrCode(string keyId, SocketInteraction interaction)
        {
            var path = "";
            var u = bll.GetUser(keyId);
            if (!string.IsNullOrEmpty(u.fa_secret))
            {
                string pth = Directory.GetCurrentDirectory() + "\\file\\";
                path = pth + $"{u.fa_secret}.png";
            }
            else
            {
                if (!redis.KeyExists("fa_secret" + keyId))
                {
                    await interaction.RespondAsync("请重新绑定2FA", ephemeral: true);
                    return;
                }
                string pth = Directory.GetCurrentDirectory() + "\\file\\";
                var pah = redis.Get<string>("fa_secret" + keyId);
                path = pth + $"{pah}.png";
            }
            if (!string.IsNullOrEmpty(path))
            {
                await interaction.RespondWithFileAsync(path, ephemeral: true);
            }
            else
            {
                await interaction.RespondAsync("二维码文件读取失败", ephemeral: true);
            }
            return;
        }

        public static async Task Bind_2FA_Fa_Secret(string keyId, SocketInteraction interaction)
        {
            var mb = new ModalBuilder()
                       .WithTitle("2FA校验")
                       .WithCustomId("menu_2fa_fa_secret")
                       .AddTextInput("2FA验证码", "input_2fa_fa_secret", placeholder: "请输入2FA验证码");
            await interaction.RespondWithModalAsync(mb.Build());
            return;
        }

        public static async Task Bind_ZhuanZhang(string keyId, SocketInteraction interaction)
        {
            var u = bll.GetUser(keyId);
            if (u != null && string.IsNullOrEmpty(u.fa_secret))
            {
                await interaction.RespondAsync("未绑定2FA", ephemeral: true);
                return;
            }
            var mb = new ModalBuilder()
                      .WithTitle("站内转账")
                      .WithCustomId("menu_zz")
                      .AddTextInput("接收UID", "input_zz_uid", placeholder: "请输入接收人UID")
                      .AddTextInput("转账数量", "input_point", placeholder: "请输入转账数量");
            await interaction.RespondWithModalAsync(mb.Build());
            return;
        }

        public static async Task Bind_BiAn(string keyId, SocketInteraction interaction)
        {
            var u = bll.GetUser(keyId);
            if (u != null && string.IsNullOrEmpty(u.fa_secret))
            {
                await interaction.RespondAsync("未绑定2FA", ephemeral: true);
                return;
            }
            var mb = new ModalBuilder()
                     .WithTitle("绑定币安")
                     .WithCustomId("menu_bdba")
                     .AddTextInput("币安UID", "input_bdba_uid", placeholder: "请输入UID")
                     .AddTextInput("2FA验证码", "input_bdba_2facode", placeholder: "请输入2FA验证码");
            await interaction.RespondWithModalAsync(mb.Build());
            return;
        }

        public static async Task Bind_WoDeYaoQing(string keyId, SocketInteraction interaction)
        {
            var msg = $"进入时间----------------被邀请人昵称";
            var str = Post(JsonConvert.SerializeObject(new
            {
                id = keyId,
            }), $"{apihost}/api/bot/InviteUser");

            var obj = JsonConvert.DeserializeObject<ApiResultEntity>(str);
            if (obj.error == 0)
            {
                var strs = JsonConvert.SerializeObject(obj.data);
                var ls = JsonConvert.DeserializeObject<List<hh_user>>(strs);

                var nameStr = "                            ";
                ls.ForEach(t =>
                {
                    msg += $"\r\n{t.usercode}{nameStr}{t.nickname}";
                });
            }

            var cb = new ComponentBuilder();
            var b = ButtonBuilder.CreateLinkButton("导出表格", $"{apihost}/api/bot/excel?id={keyId}");
            cb.WithButton(b);



            await interaction.RespondAsync(msg,
                  components: cb.Build(),
                  ephemeral: true);
        }

        public static async Task Bind_ZhuanZhang_Code(string keyId, SocketInteraction interaction)
        {
            var mb = new ModalBuilder()
                   .WithTitle("站内转账验证")
                   .WithCustomId("menu_zz_code")
                   .AddTextInput("邮箱验证码", "input_zz_mail_code", placeholder: "请输入验证码")
                   .AddTextInput("2FA验证码", "input_zz_2fa_code", placeholder: "请输入2FA验证码");
            await interaction.RespondWithModalAsync(mb.Build());
            return;
        }
    }
}
