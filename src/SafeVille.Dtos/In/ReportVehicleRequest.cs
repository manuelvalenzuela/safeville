namespace SafeVille.Dtos.In
{
    using System;

    public class ReportVehicleRequest
    {
        public string Plate { get; set; }

        public Guid? CommunityId { get; set; }
    }
}