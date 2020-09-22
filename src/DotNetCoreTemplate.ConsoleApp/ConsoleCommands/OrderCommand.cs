using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using DotNetCoreTemplate.Infrastructure.Services.Contracts;

namespace DotNetCoreTemplate.ConsoleApp.ConsoleCommands
{
    [Command("order", Description = "Start by searching orders in LyoERP")]
    public class OrderCommand
    {
        private readonly ISearchService _searchService;
        private readonly TestService _testService;
        // private readonly ILogger _logger;, ILogger logger
        public OrderCommand(ISearchService searchService, TestService testService)
        {
            _searchService = searchService;
            _testService = testService;
            // _logger = logger;
        }

        private async Task OnExecuteAsync(IConsole console)
        {
            await _searchService.SearchByOrderReferenceAsync("hehehe");
            // _logger.LogDebug("serilog debug log message");
            _testService.TestMe();
            console.WriteLine("Executing search by orders");
        }
    }
}