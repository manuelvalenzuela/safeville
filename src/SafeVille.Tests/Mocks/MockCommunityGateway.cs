namespace SafeVille.Tests.Mocks
{
    using System;
    using System.Threading.Tasks;
    using Core.Gateways;
    using Entities;

    public class MockCommunityGateway : ICommunityGateway
    {
        private const string ExistentCommunityId = "63875ef4-70d8-4cae-94c1-bf5ef0f6843c";
        private const string NonExistentCommunityId = "5b95dff2-40c8-4a05-bab2-345bab750b66";
        private const string ExistentUserId = "ed0bf589-ac19-4adb-9199-6d6686d4b60e";

        public async Task<Community> Create(Community community)
        {
            return await Task.FromResult(community);
        }

        public async Task<bool> Exists(Guid communityId)
        {
            var exist = communityId == Guid.Parse(ExistentCommunityId);
            return await Task.FromResult(exist);
        }

        public async Task<Community> GetByIdWithAdmins(Guid communityId)
        {
            var community = Community.From(Guid.Parse(ExistentUserId), "COMMUNITY_NAME");
            community.CommunityUsers.Add(
                new CommunityUser()
                {
                    UserId = Guid.Parse(ExistentUserId),
                    CommunityId = communityId
                });

            return await Task.FromResult(community);
        }
    }
}