namespace SafeVille.Core
{
    using Gateways;

    public class Context
    {
        public static ICommunityGateway CommunityGateway { get; set; }

        public static IUserGateway UserGateway { get; set; }

        public static IVehicleGateway VehicleGateway { get; set; }

        public static IVehicleReportedGateway VehicleReportedGateway { get; set; }
    }
}