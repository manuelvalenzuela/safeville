namespace SafeVille.Core
{
    using Gateways;

    public class Context
    {
        public static IPlateReportedGateway PlateReportedGateway { get; set; }

        public static IVilleGateway VilleGateway { get; set; }

        public static IUserGateway UserGateway { get; set; }

        public static ICommunityGateway CommunityGateway { get; set; }
    }
}