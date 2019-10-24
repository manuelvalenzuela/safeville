namespace SafeVille.Configurations
{
    using Core;
    using Data.Gateways;

    public class ContextConfigurator
    {
        public static void Configure()
        {
            Context.UserGateway = new UserGateway();
            Context.CommunityGateway = new CommunityGateway();
            Context.VehicleReportGateway = new VehicleReportGateway();
            Context.VehicleGateway = new VehicleGateway();
        }
    }
}