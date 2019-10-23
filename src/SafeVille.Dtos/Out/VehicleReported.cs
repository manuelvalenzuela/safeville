namespace SafeVille.Dtos.Out
{
    using System;

    public class VehicleReported
    {
        public Guid VehicleReportedId { get; set; }

        public static VehicleReported From(Guid plateReportedId)
        {
            return new VehicleReported()
            {
                VehicleReportedId = plateReportedId
            };
        }
    }
}