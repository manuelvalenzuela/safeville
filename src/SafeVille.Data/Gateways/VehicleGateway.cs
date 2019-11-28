namespace SafeVille.Data.Gateways
{
    using System.Threading.Tasks;
    using Entities;
    using Repositories;
    using SafeVille.Core.Gateways;

    public class VehicleGateway : IVehicleGateway
    {
        private readonly VehicleRepository _vehicleRepository;

        public VehicleGateway(ApplicationContext context)
        {
            _vehicleRepository = new VehicleRepository(context);
        }

        public async Task<Vehicle> RegisterKnownVehicle(Vehicle vehicle)
        {
            _vehicleRepository.Create(vehicle);
            _vehicleRepository.SaveChanges();
            return await Task.FromResult(vehicle)
                .ConfigureAwait(true);
        }
    }
}