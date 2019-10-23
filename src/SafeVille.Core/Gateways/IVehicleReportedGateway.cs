namespace SafeVille.Core.Gateways
{
    using System.Threading.Tasks;
    using Entities;

    public interface IVehicleReportedGateway
    {
        Task<VehicleReported> InsertPlateReported(VehicleReported vehicleReported);
    }
}