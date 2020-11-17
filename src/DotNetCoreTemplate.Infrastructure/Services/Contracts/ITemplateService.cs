using System.Threading.Tasks;

namespace DotNetCoreTemplate.Infrastructure.Services.Contracts
{
    public interface ITemplateService
    {
        Task<string> TemplateServiceCallAsync(string inputString);
    }
}