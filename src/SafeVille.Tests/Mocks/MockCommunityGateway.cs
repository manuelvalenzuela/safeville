using System.Threading.Tasks;
using SafeVille.Core.Gateways;
using SafeVille.Entities;

namespace SafeVille.Tests.Mocks
{
    public class MockCommunityGateway : ICommunityGateway
    {
        public async Task<Community> Create(Community community)
        {
            return await Task.FromResult(community);
        }
    }
}