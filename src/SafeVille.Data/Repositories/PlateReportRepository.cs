namespace SafeVille.Data.Repositories
{
    using Entities;

    public class PlateReportRepository : Repository<VehicleReport>
    {
        public PlateReportRepository(ApplicationContext context) : base(context)
        {
        }
    }
}