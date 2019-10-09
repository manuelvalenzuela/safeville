namespace SafeVille.Core.UseCases
{
    using Dtos.Out;
    using Exceptions;

    public class ReportVehicleUseCase
    {
        public static PlateReported Report(string plate)
        {
            if (string.IsNullOrEmpty(plate))
            {
                throw new AppArgumentException(nameof(plate));
            }

            var plateReported = Entities.PlateReported.From(plate);
            var inserted = Context.PlateReportedGateway.InsertPlateReported(plateReported);
            var isKnown = Context.VilleGateway.IsKnown(plate);
            //if (isKnown)
            //{
            //    Context.VilleGateway.Notify(plate);
            //}

            return PlateReported.From(inserted.PlateReportedId);
        }
    }
}