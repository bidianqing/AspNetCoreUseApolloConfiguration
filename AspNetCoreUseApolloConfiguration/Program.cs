using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreUseApolloConfiguration
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    hostingContext.Configuration = config.Build();
                    string apollo_MetaServer = hostingContext.Configuration["Apollo:MetaServer"];
                    string appId = hostingContext.Configuration["Apollo:AppId"];

                    config.AddApollo(new ApolloOptions
                    {
                        AppId = appId,
                        MetaServer = apollo_MetaServer
                    })
                    .AddNamespace("database", ConfigFileFormat.Json);

                    hostingContext.Configuration = config.Build();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
