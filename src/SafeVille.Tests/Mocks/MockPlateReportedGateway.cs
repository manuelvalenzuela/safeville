namespace SafeVille.Tests.Mocks
{
    using Core.Gateways;
    using Entities;

    public class MockPlateReportedGateway : IPlateReportedGateway
    {
        public PlateReported InsertPlateReported(PlateReported plateReported)
        {
          return new PlateReported()
          {
              PlateReportedId = plateReported.PlateReportedId,
              Plate = plateReported.Plate
          };  
        }
    }
}