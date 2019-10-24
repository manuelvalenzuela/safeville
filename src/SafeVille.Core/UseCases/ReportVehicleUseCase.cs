namespace SafeVille.Core.UseCases
{
    using System;
    using System.Threading.Tasks;
    using Dtos.In;
    using Dtos.Out;
    using Exceptions;

    public static class ReportVehicleUseCase
    {
        public static async Task<VehicleReport> Report(ReportVehicleRequest reportVehicle)
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

            if (reportVehicle.UserId == null || reportVehicle.UserId == Guid.Empty)
            {
                throw new AppArgumentException(nameof(reportVehicle.UserId));
            }

            var vehicleReport = Entities.VehicleReport.From(reportVehicle.Plate, reportVehicle.CommunityId.Value, reportVehicle.UserId.Value);
            var inserted = await Context.VehicleReportGateway.InsertPlateReport(vehicleReport);

            return VehicleReport.From(inserted.VehicleReportId);
        }
    }
}