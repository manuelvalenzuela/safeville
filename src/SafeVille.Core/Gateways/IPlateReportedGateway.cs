namespace SafeVille.Core.Gateways
{
    using Entities;

    public interface IPlateReportedGateway
    {
        PlateReported InsertPlateReported(PlateReported plateReported);
    }
}