namespace SafeVille.Entities
{
    using System;
    
    public class VehicleReported : IEntity
    {
        public Guid VehicleReportedId { get; set; }

        public string Plate { get; set; }

        public Guid CommunityId { get; set; }

        public Guid UserId { get; set; }

        public static VehicleReported From(string plate, Guid communityId, Guid userId)
        {
            return new VehicleReported()
            {
                VehicleReportedId = Guid.NewGuid(),
                Plate = plate,
                CommunityId = communityId,
                UserId = userId
            };
        }
    }
}