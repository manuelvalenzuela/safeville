namespace SafeVille.Tests.Mocks
{
    using System.Threading.Tasks;
    using Core.Gateways;
    using Entities;

    public class MockVehicleReportedGateway : IVehicleReportedGateway
    {
        public Task<VehicleReported> InsertPlateReported(VehicleReported vehicleReported)
        {
            return Task.FromResult(new VehicleReported()
            {
                VehicleReportedId = vehicleReported.VehicleReportedId,
                Plate = vehicleReported.Plate
            });
        }
    }
}