using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace YiSha.Admin.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseUrls("http://*:5000")
                   .UseStartup<Startup>()
                   .ConfigureLogging(logging =>
                   {
                       logging.ClearProviders();
                       logging.SetMinimumLevel(LogLevel.Trace);
                   }).UseNLog();

        /// <summary>
        /// 位运算
        /// </summary>
        public static void Operation()
        {
            #region 位运算
            long stateResult = 0;

            stateResult += 1;
            stateResult += 2 << 16;
            stateResult |= 0x100000000;

            int a = 1 ^ 2;
            int b = 1 ^ 1;
            int c = 5 & 6;
            #endregion
        }
    }
}
