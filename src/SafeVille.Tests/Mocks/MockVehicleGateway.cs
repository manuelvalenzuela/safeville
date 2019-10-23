namespace SafeVille.Tests.Mocks
{
    using System.Threading.Tasks;
    using Core.Gateways;
    using Entities;

    public class MockVehicleGateway : IVehicleGateway
    {
        public async Task<Vehicle> RegisterKnownVehicle(Vehicle vehicle)
        {
            return await Task.FromResult(vehicle);
        }
    }
}