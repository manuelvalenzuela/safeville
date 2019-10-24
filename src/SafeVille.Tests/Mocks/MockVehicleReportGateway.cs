namespace SafeVille.Tests.Mocks
{
    using System.Threading.Tasks;
    using Core.Gateways;
    using Entities;

    public class MockVehicleReportGateway : IVehicleReportGateway
    {
        public Task<VehicleReport> InsertPlateReport(VehicleReport vehicleReport)
        {
            return Task.FromResult(new VehicleReport()
            {
                VehicleReportId = vehicleReport.VehicleReportId,
                Plate = vehicleReport.Plate
            });
        }
    }
}