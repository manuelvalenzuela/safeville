namespace SafeVille.Tests.Mocks
{
    using System;
    using System.Threading.Tasks;
    using Core.Gateways;
    using Entities;

    public class MockUserGateway : IUserGateway
    {
        private const string ExistentUserId = "ed0bf589-ac19-4adb-9199-6d6686d4b60e";
        private const string NonExistentUserId = "ab0bf589-ac19-4adb-6543-6d6686d4b60e";

        public async Task<bool> Exists(Guid userId)
        {
            var exists = userId == Guid.Parse(ExistentUserId);
            return await Task.FromResult(exists);
        }

        public async Task<KnownVehicle> RegisterKnownVehicle(KnownVehicle knownVehicle)
        {
            return await Task.FromResult(knownVehicle);
        }
    }
}