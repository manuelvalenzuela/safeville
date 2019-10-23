namespace SafeVille.Data.Repositories
{
    using Entities;

    public class VehicleRepository : Repository<Vehicle>
    {
        public VehicleRepository(ApplicationContext context) : base(context)
        {
        }
    }
}