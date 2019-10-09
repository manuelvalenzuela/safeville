namespace SafeVille.Dtos.Out
{
    using System;

    public class PlateReported
    {
        public Guid PlateReportedId { get; set; }

        public static PlateReported From(Guid plateReportedId)
        {
            return new PlateReported()
            {
                PlateReportedId = plateReportedId
            };
        }
    }
}