namespace SafeVille.Entities
{
    using System;
    
    public class VehicleReport : IEntity
    {
        public Guid VehicleReportId { get; set; }

        public string Plate { get; set; }

        public Guid CommunityId { get; set; }

        public Guid UserId { get; set; }

        public static VehicleReport From(string plate, Guid communityId, Guid userId) => new VehicleReport()
        {
            VehicleReportId = Guid.NewGuid(),
            Plate = plate,
            CommunityId = communityId,
            UserId = userId
        };
    }
}
