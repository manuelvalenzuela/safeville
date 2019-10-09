namespace SafeVille.Core
{
    using Gateways;

    public class Context
    {
        public static IPlateReportedGateway PlateReportedGateway { get; set; }
        public static IVilleGateway VilleGateway { get; set; }
    }
}