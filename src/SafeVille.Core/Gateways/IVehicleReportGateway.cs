namespace SafeVille.Core.Gateways
{
    using System.Threading.Tasks;
    using Entities;

    public interface IVehicleReportGateway
    {
        Task<VehicleReport> InsertPlateReport(VehicleReport vehicleReport);
    }
}