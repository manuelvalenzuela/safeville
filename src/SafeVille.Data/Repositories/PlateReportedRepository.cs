namespace SafeVille.Data.Repositories
{
    using Entities;

    public class PlateReportedRepository : Repository<VehicleReported>
    {
        public PlateReportedRepository(ApplicationContext context) : base(context)
        {
        }
    }
}