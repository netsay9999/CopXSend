using Discord.WebSocket;
using Discord;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;
using H.RedisTools;
using Discord.Commands;
using H.Saas.Tools;
using H.Bot.BotModels;
using Discord.Rest;
using NetTaste;
using SixLabors.ImageSharp.Drawing;
using Microsoft.VisualBasic;
using System.Security.Cryptography;

namespace MySecondBot
{
    public class Program : BaseBll
    {
        private static DiscordSocketClient _client;
        public static UserBotBll bll = new UserBotBll();
        public static async Task Main()
        {

            //Console.WriteLine(str);
            //new CreateBll().CreateModel();
            await MaiX();


            //var guid = Identity;
            //var key = "123";
            //var gg = bll.Google(key, guid);
            //GoogleAuthenticator gat = new GoogleAuthenticator();
            //var result = gat.ValidateTwoFactorPIN("0xa5f65fce2c05437885aedc29125f9c88de3f727c", "562721");

            //var str = "data:image/png;base64,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B4AAQQeAAEEHgABBB4AAQQeAAEEHgIBc0G0j/+y287N72/k5fHt/2hb6OnybfZrbvu/tckEHgBsJOgAECDoABAg6AAQIOgAECDoABAg6AAQIOgAECDoABAg6AAQIOgAECDo/2r2F/tbu47lte//0Lf23n3/6Vvxtxz9ti376/UTQASBA0AEgQNABIEDQASBA0AEgQNABIEDQASBA0AEgQNABIEDQASBA0AEgQNAvsw7fQt99PNO2rKdty7+1+3ye/v+atlW++/in/X5P/3/9l6ADQICgA0CAoANAgKADQICgA0CAoANAgKADQICgA0CAoANAgKADQICgA0BALuinb1/vNm1be9q2+bTrZ9qW/lu3bXFP3/r+tGnvbpj2+d+WCzoA3EjQASBA0AEgQNABIEDQASBA0AEgQNABIEDQASBA0AEgQNABIEDQASBgfNCfy7aRT3f6tjM/233+p22/73bb973t+L9tfNABgN8JOgAECDoABAg6AAQIOgAECDoABAg6AAQIOgAECDoABAg6AAQIOgAEfD3o07Z5b3P6+V+unz+1Dt9C32338azl9/uXph+/J3QACBB0AAgQdAAIEHQACBB0AAgQdAAIEHQACBB0AAgQdAAIEHQACBB0AAgQdAAIEHQACBB0AAgQdAAIEHQACBB0AAgQdAAIEHQACBB0AAgQdAAIEHQACBB0AAgQdAAIEHQACBB0AAgQdAAI+B/NUxa70Fvo4gAAAABJRU5ErkJggg==";
            //var ms = ImageHelper.SaveImg(str, "111111.png");

        }


        private static async Task MaiX()
        {
            Console.WriteLine($"系统已启动");
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                GatewayIntents = GatewayIntents.All
            });
            //日志
            _client.Log += LogAsync;
            ///消息
            _client.MessageReceived += HandleMessageReceived;
            _client.InteractionCreated += InteractionCreatedAsync;


            //接受表单信息
            _client.ModalSubmitted += FormRecived;



            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        private static async Task LogAsync(LogMessage message)
        {
            if (message.Exception is CommandException cmdException)
            {
                Console.WriteLine($"[Command/{message.Severity}] {cmdException.Command.Aliases.First()}"
                    + $" failed to execute in {cmdException.Context.Channel}.");
                Console.WriteLine(cmdException);
            }
            else
            {
                Console.WriteLine($"[General/{message.Severity}] {message}");
            }
            await Task.CompletedTask;
        }
        private static async Task HandleMessageReceived(SocketMessage message)
        {
            if (message.Author.Id == _client.CurrentUser.Id)
                return;

            if (message.Author.IsBot == true)
                return;
            var Id = message.Author.Id;
            var Username = message.Author.Username;
            var GlobalName = message.Author.GlobalName;
            var keyId = $"{Id}";
            if (!redis.KeyExists(keyId))
            {
                redis.Set(keyId, keyId);
                var str = Post(JsonConvert.SerializeObject(new
                {
                    id = Id,
                    username = Username,
                    global_name = GlobalName,
                    avatar = "",
                }), $"{apihost}/api/bot/discord_register");
            }

            var content = message.Content;
            if (string.IsNullOrEmpty(content))
                return;
            Logs.WriteLog($"Id:{Id}，用户名:{message.Author.Username}，发送消息：{content}");
            if (message.Content == "启动")
            {
                var cb = new ComponentBuilder();
                var b = ButtonBuilder.CreateLinkButton("用户授权", $"{apihost}/api/bot/Auth");
                cb.WithButton(b).WithButton("绑定推荐人", "btn_tjr", ButtonStyle.Danger)
                .WithButton("用户中心", "btn_points", ButtonStyle.Success); ;
                await message.Channel.SendMessageAsync("系统启动!", components: cb.Build());
            }
            else
            {
                bll.chat_points(keyId, chat_points);
            }
        }
        private static async Task InteractionCreatedAsync(SocketInteraction interaction)
        {
            if (interaction is SocketMessageComponent component)
            {
                var cuscomId = component.Data.CustomId;

                var id = interaction.User.Id;
                var username = interaction.User.Username;
                var keyId = $"{id}";

                switch (cuscomId)
                {
                    case "btn_tjr":
                        await Bot_Btn.Tjr(keyId, interaction);
                        break;
                    case "btn_points":
                        await Bot_Btn.UserCenter(keyId, interaction);
                        break;
                    case "btn_2FA":
                        await Bot_Btn.Bind_2FA(keyId, interaction);
                        break;
                    case "btn_2fa_qrcode":
                        await Bot_Btn.Bind_2FA_QrCode(keyId, interaction);
                        break;
                    case "btn_2fa_fa_secret":
                        await Bot_Btn.Bind_2FA_Fa_Secret(keyId, interaction);
                        break;
                    case "btn_zz":
                        await Bot_Btn.Bind_ZhuanZhang(keyId, interaction);
                        break;
                    case "btn_tx":
                        await interaction.RespondAsync($"你好，{username}，功能开发中.", ephemeral: true);
                        break;
                    case "btn_bdba":
                        await Bot_Btn.Bind_BiAn(keyId, interaction);
                        break;
                    case "btn_bdokx":
                        await interaction.RespondAsync($"你好，{username}，功能开发中.", ephemeral: true);
                        break;
                    case "btn_bdqb":
                        await interaction.RespondAsync($"你好，{username}，功能开发中.", ephemeral: true);
                        break;
                    case "btn_wdyq":
                        await Bot_Btn.Bind_WoDeYaoQing(keyId, interaction);
                        break;
                    case "btn_zz_code":
                        await Bot_Btn.Bind_ZhuanZhang_Code(keyId, interaction);
                        break;
                    default:
                        break;
                }
            }
        }

        private static async Task FormRecived(SocketModal modal)
        {
            List<SocketMessageComponentData> components =
                modal.Data.Components.ToList();
            var btnName = modal.Data.CustomId.ToLower();
            AllowedMentions mentions = new AllowedMentions();
            mentions.AllowedTypes = AllowedMentionTypes.Users;
            var username = modal.User.Username;
            var Id = modal.User.Id;
            var keyId = $"{Id}";
            switch (btnName)
            {
                case "menu_tjr":
                    await Bot_Form.Form_Tjr(keyId, components, modal, mentions);
                    break;
                case "menu_zz":
                    await Bot_Form.Form_ZhuanZhuang(keyId, components, modal, mentions);
                    break;
                case "menu_zz_code":
                    await Bot_Form.Form_ZhuanZhuang_Code(keyId, components, modal, mentions);
                    break;
                case "menu_bdba":
                    await Bot_Form.Form_BindBiAn(keyId, components, modal, mentions);
                    break;
                case "menu_2fa_fa_secret":
                    await Bot_Form.Form_2FA_Fa_Secret(keyId, components, modal, mentions);
                    break;
                default:
                    break;
            }
        }
    }
}
