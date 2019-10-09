using SafeVille.Entities;

namespace SafeVille.Core.Gateways
{
    public interface IPlateReportedGateway
    {
        PlateReported InsertPlateReported(PlateReported plateReported);
    }
}