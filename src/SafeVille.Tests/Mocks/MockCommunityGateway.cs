namespace SafeVille.Tests.Mocks
{
    using System.Threading.Tasks;
    using Core.Gateways;
    using Entities;

    public class MockCommunityGateway : ICommunityGateway
    {
        public async Task<Community> Create(Community community)
        {
            return await Task.FromResult(community);
        }
    }
}