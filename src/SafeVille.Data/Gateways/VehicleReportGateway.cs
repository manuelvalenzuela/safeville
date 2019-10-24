namespace SafeVille.Data.Gateways
{
    using System.Threading.Tasks;
    using Entities;
    using Repositories;
    using SafeVille.Core.Gateways;

    public class VehicleReportGateway : IVehicleReportGateway
    {
        private readonly PlateReportRepository _plateReportRepository;

        public VehicleReportGateway()
        {
            _plateReportRepository = new PlateReportRepository(ApplicationContext.GetInstance);
        }

        public async Task<VehicleReport> InsertPlateReport(VehicleReport vehicleReport)
        {
            _plateReportRepository.Create(vehicleReport);
            _plateReportRepository.SaveChanges();
            return await Task.FromResult(vehicleReport)
                .ConfigureAwait(true);
        }
    }
}