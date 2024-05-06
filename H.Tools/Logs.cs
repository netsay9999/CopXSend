using System;
using System.IO;

namespace H.Saas.Tools
{
    public static class Logs
    {

        public static void WriteLog(string msg, string pathName = "")
        {
            string path = Directory.GetCurrentDirectory() + "/logs/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string logPath = path + pathName + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            try
            {
                using (StreamWriter sw = File.AppendText(logPath))
                {
                    sw.WriteLine("时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    sw.WriteLine(msg);
                    sw.WriteLine("**************************************************");
                    sw.WriteLine();
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
            catch (IOException e)
            {
                using (StreamWriter sw = File.AppendText(logPath))
                {
                    sw.WriteLine("时间：" + DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"));
                    sw.WriteLine("异常：" + e.Message);
                    sw.WriteLine("**************************************************");
                    sw.WriteLine();
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }

    }
}
