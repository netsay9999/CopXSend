using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySecondBot
{
    public class CreateBll : BaseBll
    {
        public void CreateModel()
        {
            dbContent.DbFirst.IsCreateAttribute().CreateClassFile(@"D:\2024\CopxBot\MySecondBot\BotModels", "H.Bot.BotModels");
        }
    }
}
