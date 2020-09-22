using System.Threading.Tasks;
using DotNetCoreTemplate.Infrastructure.Services.Contracts;

namespace DotNetCoreTemplate.Infrastructure.Services
{
    public class SearchService : ISearchService
    {
        public SearchService()
        {

        }

        public async Task<string> SearchByOrderReferenceAsync(string orderReference)
        {
            await Task.FromResult(false);
            return "tralala";
        }
    }
}