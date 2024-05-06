using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json.Linq;

namespace H.RedisTools
{
    public class Configs
    {
        //https://www.cnblogs.com/pudefu/p/7580722.html
        //读取配置文件的代码完成了，只要引用了NetCoreOrder.Common类库的项目中都能方便读取数据库链接字符串和其他配置，使用方法如下：

        //AppConfigurtaionServices.Configuration.GetConnectionString("CxyOrder"); 
        ////得到 Server=LAPTOP-AQUL6MDE\\MSSQLSERVERS;Database=CxyOrder;User ID=sa;Password=123456;Trusted_Connection=False;


        //读取一级配置节点配置

        //AppConfigurtaionServices.Configuration["ServiceUrl"];
        ////得到 https://www.baidu.com/getnews


        //读取二级子节点配置

        //AppConfigurtaionServices.Configuration["Appsettings:SystemName"];
        ////得到 PDF .NET CORE
        //AppConfigurtaionServices.Configuration["Appsettings:Author"];
        ////得到 PDF

        public static IConfiguration Configuration { get; set; }
        static Configs()
        {
            //ReloadOnChange = true 当appsettings.json被修改时重新加载    
            Configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();
        }
    }
    public static class ConfigM
    {
        public static string ConfigFile { set; get; } = "config.json";
        private static JObject BuildItems()
        {
            var json = File.ReadAllText(ConfigFile);
            return JObject.Parse(json);
        }

        public static JObject Items
        {
            get
            {
                if (_Items == null)
                {
                    _Items = BuildItems();
                }
                return _Items;
            }
        }
        private static JObject _Items;


        public static T GetValue<T>(string key)
        {
            return Items[key].Value<T>();
        }

        public static String[] GetStringList(string key)
        {
            return Items[key].Select(x => x.Value<String>()).ToArray();
        }

        public static String GetString(string key)
        {
            return GetValue<String>(key);
        }

        public static int GetInt(string key)
        {
            return GetValue<int>(key);
        }
    }
}
