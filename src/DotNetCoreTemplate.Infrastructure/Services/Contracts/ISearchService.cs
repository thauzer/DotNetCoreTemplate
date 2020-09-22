using System.Threading.Tasks;

namespace DotNetCoreTemplate.Infrastructure.Services.Contracts
{
    public interface ISearchService
    {
        Task<string> SearchByOrderReferenceAsync(string orderReference);
    }
}