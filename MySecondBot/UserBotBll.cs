﻿using Google.Authenticator;
using H.Bot.BotModels;
using H.Saas.Tools;
using System;
using System.Threading.Tasks;
namespace MySecondBot
{
    public class UserBotBll : BaseBll
    {
        public void chat_points(string keyId, decimal points)
        {
            dbContent.Updateable<hh_user>().SetColumns(t => new hh_user
            {
                chat = t.chat + points,
            }).Where(t => t.discord_id == keyId).ExecuteCommand();
        }
        public ApiResultEntity chat_bindBiAn(string keyId, string uid)
        {
            var count = dbContent.Updateable<hh_user>().SetColumns(t => new hh_user
            {
                Binanceid = uid,
                bindBinance = true,
            }).Where(t => t.discord_id == keyId && string.IsNullOrEmpty(t.Binanceid)).ExecuteCommand();

            return Success(count > 0);
        }

        /// <summary>
        /// 站内转账验证码
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public ApiResultEntity SendEmail(string keyId, string code, decimal? point, string uid)
        {
            var user = dbContent.Queryable<hh_user>().First(t => t.discord_id == keyId);
            if (user == null)
                return Errors();
            var id = Convert.ToInt32(uid);
            var toUser = dbContent.Queryable<hh_user>().First(t => t.id == id);
            if (toUser == null)
                return Errors("接受用户不存在");

            if (user.copx < point)
                return Errors("CopX不足");
            Task.Run(() =>
            {
                new Mail().Send(new MailIfo
                {
                    body = code,
                    receiverAddess = user.email,
                    senderAddress = senderAddress,
                    smtpHost = smtpHost,
                    smtpPassword = smtpPassword,
                    smtpPort = smtpPort,
                    subject = $"{mail_AppName}转账验证。"
                });
            });

            return Success("", user);
        }
        public SetupCode Google(string key, string Guids)
        {
            GoogleAuthenticator gat = new GoogleAuthenticator();
            return gat.GenerateSetupCode("Copx", key, Guids, 2);
        }


        public ApiResultEntity chat_bind2Fa(string keyId, string guid)
        {
            var u = dbContent.Queryable<hh_user>().First(t => t.discord_id == keyId);
            if (u == null) return Errors();

            if (!string.IsNullOrEmpty(u.fa_secret))
                return Errors("2FA已绑定");
            u.fa_secret = guid;
            var cnt = dbContent.Updateable(u).ExecuteCommand();

            return Success(cnt > 0, u);
        }

        public ApiResultEntity chat_check2fa(string keyId, string input_zz_2fa_code)
        {
            var u = dbContent.Queryable<hh_user>().First(t => t.discord_id == keyId);
            if (u == null) return Errors();

            if (string.IsNullOrEmpty(u.fa_secret))
                return Errors("未绑定2FA");

            GoogleAuthenticator gat = new GoogleAuthenticator();
            var result = gat.ValidateTwoFactorPIN(u.fa_secret, input_zz_2fa_code);
            if (result)
                return Success();

            return Errors();
        }

        public hh_user GetUser(string keyId)
        {
            return dbContent.Queryable<hh_user>().First(t => t.discord_id == keyId);
        }

        internal void SendEmail(hh_user u, string code)
        {
            Task.Run(() =>
            {
                new Mail().Send(new MailIfo
                {
                    body = code,
                    receiverAddess = u.email,
                    senderAddress = senderAddress,
                    smtpHost = smtpHost,
                    smtpPassword = smtpPassword,
                    smtpPort = smtpPort,
                    subject = $"{mail_AppName}，提现验证。"
                });
            });
        }

        internal void Bind_Bsc(hh_user u, string input_bind_bsc, int type)
        {
            if (type == 0)
                u.address_bsc = input_bind_bsc;
            if (type == 1)
                u.address_usdt = input_bind_bsc;
            dbContent.Updateable(u).ExecuteCommand();
        }
    }
}
