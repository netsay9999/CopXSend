namespace MySecondBot
{
    public class CreateBll : BaseBll
    {
        public void CreateModel()
        {
            dbContent.DbFirst.IsCreateAttribute().CreateClassFile(@"E:\2024项目\CopxBot\MySecondBot\BotModels", "H.Bot.BotModels");
        }
    }
}
