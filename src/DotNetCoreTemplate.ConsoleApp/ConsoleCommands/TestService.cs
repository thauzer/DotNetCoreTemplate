using Microsoft.Extensions.Logging;

namespace DotNetCoreTemplate.ConsoleApp.ConsoleCommands
{
    public class TestService
    {
        private readonly ILogger _logger;
        public TestService(ILogger logger) {
            _logger = logger;
        }

        public void TestMe() {
            _logger.LogDebug("test me");
        }
    }
}