namespace SafeVille.Dtos.Out
{
    using System;

    public class VehicleReport
    {
        public Guid VehicleReportId { get; set; }

        public static VehicleReport From(Guid plateReportId)
        {
            return new VehicleReport()
            {
                VehicleReportId = plateReportId
            };
        }
    }
}