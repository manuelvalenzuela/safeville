namespace SafeVille.Core.UseCases
{
    using System;
    using Dtos.In;
    using Dtos.Out;
    using Exceptions;

    public static class ReportVehicleUseCase
    {
        public static PlateReported Report(ReportVehicleRequest reportVehicle)
        {
            if (reportVehicle == null)
            {
                throw new AppArgumentException(nameof(reportVehicle));
            }

            if (string.IsNullOrWhiteSpace(reportVehicle.Plate))
            {
                throw new AppArgumentException(nameof(reportVehicle.Plate));
            }

            if (reportVehicle.CommunityId == null || reportVehicle.CommunityId == Guid.Empty)
            {
                throw new AppArgumentException(nameof(reportVehicle.CommunityId));
            }

            var plateReported = Entities.PlateReported.From(reportVehicle.Plate, reportVehicle.CommunityId.Value);
            var inserted = Context.PlateReportedGateway.InsertPlateReported(plateReported);
            
            return PlateReported.From(inserted.PlateReportedId);
        }
    }
}