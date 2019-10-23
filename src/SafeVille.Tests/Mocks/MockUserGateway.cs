namespace SafeVille.Tests.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core.Gateways;
    using Entities;

    public class MockUserGateway : IUserGateway
    {
        private const string ExistentUserId = "ed0bf589-ac19-4adb-9199-6d6686d4b60e";
        private const string NonExistentUserId = "ab0bf589-ac19-4adb-6543-6d6686d4b60e";
        private const string ExistentNotInvitedUserId = "ef0bf589-ac19-4adb-0987-6d6686d4b60e";
        private const string ExistentUserIdThatDontBelongToCommunityAdmins = "473e95d1-338d-4776-af44-1a346c19b8c6";

        private readonly List<Guid> _userIds;

        public MockUserGateway()
        {
            _userIds = new List<Guid>
            {
                Guid.Parse(ExistentUserId),
                Guid.Parse(ExistentNotInvitedUserId),
                Guid.Parse(ExistentUserIdThatDontBelongToCommunityAdmins)
            };
        }

        public async Task<bool> Exists(Guid userId)
        {
            var exists = _userIds.Contains(userId);
            return await Task.FromResult(exists);
        }
    }
}