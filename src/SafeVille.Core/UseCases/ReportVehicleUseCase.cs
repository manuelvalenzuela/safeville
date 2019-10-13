namespace SafeVille.Core.UseCases
{
    using Dtos.Out;
    using Exceptions;

    public static class ReportVehicleUseCase
    {
        public static PlateReported Report(string plate)
        {
            if (string.IsNullOrEmpty(plate))
            {
                throw new AppArgumentException(nameof(plate));
            }

            var plateReported = Entities.PlateReported.From(plate);
            var inserted = Context.PlateReportedGateway.InsertPlateReported(plateReported);
            
            return PlateReported.From(inserted.PlateReportedId);
        }
    }
}