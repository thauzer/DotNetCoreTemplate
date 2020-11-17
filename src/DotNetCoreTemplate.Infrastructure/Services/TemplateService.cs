using System.Threading.Tasks;
using DotNetCoreTemplate.Infrastructure.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace DotNetCoreTemplate.Infrastructure.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly ILogger _logger;
        public TemplateService(ILogger<TemplateService> logger)
        {
            _logger = logger;
        }

        public async Task<string> TemplateServiceCallAsync(string orderReference)
        {
            _logger.LogDebug("Execute template service call");
            await Task.FromResult(false);
            return "outString";
        }
    }
}