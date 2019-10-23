namespace SafeVille.Core.Gateways
{
    using System.Threading.Tasks;
    using Entities;

    public interface IVehicleGateway
    {
        Task<Vehicle> RegisterKnownVehicle(Vehicle vehicle);
    }
}