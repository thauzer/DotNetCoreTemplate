using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using System.Reflection;
using DotNetCoreTemplate.Infrastructure.Services.Contracts;
using DotNetCoreTemplate.Infrastructure.Services;
using Serilog;
using DotNetCoreTemplate.ConsoleApp.ConsoleCommands;

namespace DotNetCoreTemplate.ConsoleApp
{
    [Command(Name = "DotNetCoreTemplate", Description = "A tool for getting all the information about a order/payment")]
    [HelpOption]
    [VersionOptionFromMember(MemberName = "GetVersion")]
    [Subcommand(
        typeof(DotNetCoreTemplate.ConsoleApp.ConsoleCommands.OrderCommand)
    )]
    class Program
    {
        public static async Task Main(string[] args)
        {

            var host = CreateHost();

            await host.RunCommandLineApplicationAsync<Program>(args);
        }

        public static IHostBuilder CreateHost()
        {
            var host = new HostBuilder();
            host.ConfigureLogging(factory =>
            {
                factory.AddSerilog();   
            })
            .ConfigureAppConfiguration((hostContext, configApp) =>
            {
                configApp.SetBasePath(Directory.GetCurrentDirectory());
                configApp.AddJsonFile("appsettings.json", true, true);

                var envName = hostContext.HostingEnvironment.EnvironmentName;

                // configApp.AddJsonFile($"appsettings.{envName}.json", true, true);
                configApp.AddEnvironmentVariables(prefix: "PAYMENTCHECK_");
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddScoped<ISearchService, SearchService>();
                services.AddScoped<TestService>();
            })
            .UseSerilog()
            .UseConsoleLifetime();


            return host;
        }

        private int OnExecute(CommandLineApplication app, IConsole console)
        {
            console.WriteLine("You must specify a command");
            app.ShowHelp();
            return 1;
        }

        private string GetVersion()
        {
            return typeof(Program).Assembly
                ?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;
        }
    }
}
