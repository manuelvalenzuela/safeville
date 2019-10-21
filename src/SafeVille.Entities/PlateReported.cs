namespace SafeVille.Entities
{
    using System;
    
    public class PlateReported
    {
        public Guid PlateReportedId { get; set; }

        public string Plate { get; set; }

        public static PlateReported From(string plate, Guid communityId)
        {
            return new PlateReported()
            {
                PlateReportedId = Guid.NewGuid(),
                Plate = plate
            };
        }
    }
}