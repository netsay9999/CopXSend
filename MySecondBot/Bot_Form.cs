﻿using Discord;
using Discord.WebSocket;
using H.Bot.BotModels;
using H.RedisTools;
using H.Saas.Tools;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySecondBot
{
    public class Bot_Form : BaseBll
    {
        public static UserBotBll bll = new UserBotBll();
        public static async Task Form_Tjr(string keyId, List<SocketMessageComponentData> components, SocketModal modal, AllowedMentions mentions)
        {
            string tjr = components.First(x => x.CustomId == "input_tjr").Value;
            var str = Post(JsonConvert.SerializeObject(new
            {
                id = keyId,
                usercode = tjr,
            }), $"{apihost}/api/bot/BindParent");
            var obj = JsonConvert.DeserializeObject<ApiResultEntity>(str);
            await modal.RespondAsync(obj.msg, allowedMentions: mentions, ephemeral: true);
            return;
        }

        internal static async Task Form_2FA_Fa_Secret(string keyId, List<SocketMessageComponentData> components, SocketModal modal, AllowedMentions mentions)
        {
            string input_2fa_fa_secret = components.First(x => x.CustomId == "input_2fa_fa_secret").Value;

            if (!redis.KeyExists("fa_secret" + keyId))
            {
                await modal.RespondAsync("验证已过期", allowedMentions: mentions, ephemeral: true);
                return;
            }
            var privateKey = redis.Get<string>("fa_secret" + keyId);
            GoogleAuthenticator gat = new GoogleAuthenticator();
            var result = gat.ValidateTwoFactorPIN(privateKey, input_2fa_fa_secret);
            if (!result)
            {
                await modal.RespondAsync("2FA验证失败", allowedMentions: mentions, ephemeral: true);
                return;
            }
            else
            {
                var obj = bll.chat_bind2Fa(keyId, privateKey);
                if (obj.success)
                {
                    //await modal.RespondAsync("2FA已绑定，请妥善保存秘钥文件",allowedMentions: mentions, ephemeral: true);

                    var cb = new ComponentBuilder()
                            .WithButton("站内转账", "btn_zz", ButtonStyle.Success)
                            .WithButton("COPX提现", "btn_tx", ButtonStyle.Success)
                            .WithButton("绑定币安", "btn_bdba", ButtonStyle.Success)
                            .WithButton("绑定OKX", "btn_bdokx", ButtonStyle.Success)
                            .WithButton("绑定钱包", "btn_bdqb", ButtonStyle.Success)
                            .WithButton("我的邀请", "btn_wdyq", ButtonStyle.Success);
                    await modal.RespondAsync("2FA已绑定，请妥善保存秘钥文件", components: cb.Build(), ephemeral: true);
                }
                else
                {
                    await modal.RespondAsync(obj.msg, allowedMentions: mentions, ephemeral: true);
                }
            }

            return;
        }

        internal static async Task Form_BindBiAn(string keyId, List<SocketMessageComponentData> components, SocketModal modal, AllowedMentions mentions)
        {
            string uid = components.First(x => x.CustomId == "input_bdba_uid").Value;
            string input_bdba_2facode = components.First(x => x.CustomId == "input_bdba_2facode").Value;

            var u = bll.GetUser(keyId);
            if (u == null)
            {
                await modal.RespondAsync("账号错误", allowedMentions: mentions, ephemeral: true);
                return;
            }
            if (!string.IsNullOrEmpty(u.Binanceid))
            {
                await modal.RespondAsync("币安账号已绑定", allowedMentions: mentions, ephemeral: true);
                return;
            }
            if (string.IsNullOrEmpty(u.fa_secret))
            {
                await modal.RespondAsync("2FA秘钥提取错误", allowedMentions: mentions, ephemeral: true);
                return;
            }

            GoogleAuthenticator gat = new GoogleAuthenticator();
            var result = gat.ValidateTwoFactorPIN(u.fa_secret, input_bdba_2facode);
            if (result)
            {
                var obj = bll.chat_bindBiAn(keyId, uid);
                await modal.RespondAsync(obj.msg, allowedMentions: mentions, ephemeral: true);
            }
            else
            {
                await modal.RespondAsync("2FA验证失败", allowedMentions: mentions, ephemeral: true);
            }
            return;
        }

        internal static async Task Form_bind_bsc(string keyId, List<SocketMessageComponentData> components, SocketModal modal, AllowedMentions mentions)
        {
            var input_bind_bsc = components.First(x => x.CustomId == "input_bind_bsc").Value;
            string input_tx_copx_2Fa = components.First(x => x.CustomId == "input_tx_copx_2Fa").Value;
            var u = bll.GetUser(keyId);
            if (!string.IsNullOrEmpty(u.address_bsc))
            {
                await modal.RespondAsync("BSC钱包已绑定", allowedMentions: mentions, ephemeral: true);
                return;
            }
            GoogleAuthenticator gat = new GoogleAuthenticator();
            var result = gat.ValidateTwoFactorPIN(u.fa_secret, input_tx_copx_2Fa);
            if (result == false)
            {
                await modal.RespondAsync("2FA验证失败", allowedMentions: mentions, ephemeral: true);
                return;
            }
            bll.Bind_Bsc(u, input_bind_bsc, 0);
            var msg =
                 $"\r\nBSC钱包绑定成功" +
                 $"\r\n\r\n:绑定地址：{input_bind_bsc}";
            await modal.RespondAsync(msg, allowedMentions: mentions, ephemeral: true);
            return;
        }

        internal static async Task Form_bind_usdt(string keyId, List<SocketMessageComponentData> components, SocketModal modal, AllowedMentions mentions)
        {
            var input_bind_usdt = components.First(x => x.CustomId == "input_bind_usdt").Value;
            string input_tx_copx_2Fa = components.First(x => x.CustomId == "input_tx_copx_2Fa").Value;
            var u = bll.GetUser(keyId);
            if (!string.IsNullOrEmpty(u.address_usdt))
            {
                await modal.RespondAsync("USDT钱包已绑定", allowedMentions: mentions, ephemeral: true);
                return;
            }
            GoogleAuthenticator gat = new GoogleAuthenticator();
            var result = gat.ValidateTwoFactorPIN(u.fa_secret, input_tx_copx_2Fa);
            if (result == false)
            {
                await modal.RespondAsync("2FA验证失败", allowedMentions: mentions, ephemeral: true);
                return;
            }
            bll.Bind_Bsc(u, input_bind_usdt, 1);
            var msg =
                 $"\r\nUSDT钱包绑定成功" +
                 $"\r\n\r\n:绑定地址：{input_bind_usdt}";
            await modal.RespondAsync(msg, allowedMentions: mentions, ephemeral: true);
        }

        internal static async Task Form_tx_copx(string keyId, List<SocketMessageComponentData> components, SocketModal modal, AllowedMentions mentions)
        {
            var point = (components.First(x => x.CustomId == "input_tx_copx").Value).NumX(6);
            string input_tx_copx_2Fa = components.First(x => x.CustomId == "input_tx_copx_2Fa").Value;
            var u = bll.GetUser(keyId);
            if (u.copx < point)
            {
                await modal.RespondAsync("Copx 不足", allowedMentions: mentions, ephemeral: true);
                return;
            }
            GoogleAuthenticator gat = new GoogleAuthenticator();
            var result = gat.ValidateTwoFactorPIN(u.fa_secret, input_tx_copx_2Fa);
            if (result == false)
            {
                await modal.RespondAsync("2FA验证失败", allowedMentions: mentions, ephemeral: true);
                return;
            }
            var code = AutoNum(99999, 999999);
            bll.SendEmail(u, code);
            redis.Set("SendEmail" + keyId, new hh_user
            {
                chat = point,
                discord_id = "",
                Binanceid = code,
                id = 2,
            }, 1, DType.Hours);
            var cb = new ComponentBuilder();
            cb.WithButton("提现验证", "btn_zz_code", ButtonStyle.Success);
            var msg = $"Copx提现，当前剩余个数：{u.copx}，转出数量：{point}。";
            await modal.RespondAsync(msg, components: cb.Build(), ephemeral: true);
        }

        internal static async Task Form_ZhuanZhuang(string keyId, List<SocketMessageComponentData> components, SocketModal modal, AllowedMentions mentions)
        {

            string input_zz_2fa_code = components.First(x => x.CustomId == "input_zz_2fa_code").Value;
            var obj = bll.chat_check2fa(keyId, input_zz_2fa_code);
            if (obj.success)
            {
                string uid = components.First(x => x.CustomId == "input_zz_uid").Value;
                decimal? point = (components.First(x => x.CustomId == "input_point").Value).NumX(2);
                var code = AutoNum(99999, 999999);
                obj = bll.SendEmail(keyId, code, point, uid);
                if (obj.success)
                {
                    var user = obj.data as hh_user;
                    redis.Set("SendEmail" + keyId, new hh_user
                    {
                        chat = point,
                        discord_id = uid,
                        Binanceid = code,
                        id = 1,
                    }, 1, DType.Hours);
                    //components = new List<SocketMessageComponentData>();
                    var cb = new ComponentBuilder();
                    cb.WithButton("转账验证", "btn_zz_code", ButtonStyle.Success);
                    var msg = $"Copx转出，当前剩余个数：{user.copx}，接收用户UID：{uid}，转出数量：{point}。";
                    await modal.RespondAsync(msg, components: cb.Build(), ephemeral: true);
                }
                else
                {
                    await modal.RespondAsync(obj.msg, allowedMentions: mentions, ephemeral: true);
                }
            }
            else
            {
                await modal.RespondAsync("2FA验证失败", allowedMentions: mentions, ephemeral: true);
            }
            return;
        }

        internal static async Task Form_ZhuanZhuang_Code(string keyId, List<SocketMessageComponentData> components, SocketModal modal, AllowedMentions mentions)
        {
            string input_zz_mail_code = components.First(x => x.CustomId == "input_zz_mail_code").Value;
            var model = redis.Get<hh_user>("SendEmail" + keyId);
            if (model == null)
            {
                await modal.RespondAsync("Email验证码已过期", allowedMentions: mentions, ephemeral: true);
                return;
            }
            if (model.Binanceid != input_zz_mail_code)
            {
                await modal.RespondAsync("Email验证码校验失败", allowedMentions: mentions, ephemeral: true);
                return;
            }

            var sr = $"{keyId}{model.discord_id}copxbot";
            var privatekey = Md5Helper.MdEncrypt(sr, 32);
            //id=1转账
            //id=2提现
            var host = $"{apihost}/api/bot/copx_to_copx";
            if (model.id == 2)
                host = $"{apihost}/api/bot/copx_to_bnb";
            var str = Post(JsonConvert.SerializeObject(new
            {
                privatekey = privatekey,
                id = keyId,
                otherid = model.discord_id,
                num = model.chat,
            }), host);
            var obj = JsonConvert.DeserializeObject<ApiResultEntity>(str);

            await modal.RespondAsync(obj.msg, allowedMentions: mentions, ephemeral: true);

            return;
        }
    }
}
