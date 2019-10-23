namespace SafeVille.Data.Gateways
{
    using System.Threading.Tasks;
    using Entities;
    using Repositories;
    using SafeVille.Core.Gateways;

    public class VehicleReportedGateway : IVehicleReportedGateway
    {
        private readonly PlateReportedRepository _plateReportedRepository;

        public VehicleReportedGateway()
        {
            _plateReportedRepository = new PlateReportedRepository(ApplicationContext.GetInstance);
        }

        public async Task<VehicleReported> InsertPlateReported(VehicleReported vehicleReported)
        {
            _plateReportedRepository.Create(vehicleReported);
            _plateReportedRepository.SaveChanges();
            return await Task.FromResult(vehicleReported)
                .ConfigureAwait(true);
        }
    }
}