using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using DotNetCoreTemplate.Infrastructure.Services.Contracts;

namespace DotNetCoreTemplate.ConsoleApp.ConsoleCommands
{
    [Command("template", Description = "template command")]
    public class TemplateCommand
    {
        private readonly ITemplateService _templateService;
        private readonly ILogger _logger;
        public TemplateCommand(ILogger<TemplateCommand> logger, ITemplateService templateService)
        {
            _templateService = templateService;
            _logger = logger;
        }

        private async Task OnExecuteAsync(IConsole console)
        {
            _logger.LogDebug("Executing TemplateCommand");
            var result = await _templateService.TemplateServiceCallAsync("inputString");
            _logger.LogDebug($"Result: {result}");
        }
    }
}