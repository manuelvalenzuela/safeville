namespace SafeVille.Entities
{
    using System;

    public class KnownVehicle
    {
        public Guid KnownVehicleId { get; set; }

        public Guid AccountableUserId { get; set; }

        public string Plate { get; set; }

        public static KnownVehicle From(Guid accountableUserId, string plate)
        {
            return new KnownVehicle
            {
                KnownVehicleId = Guid.NewGuid(),
                AccountableUserId = accountableUserId,
                Plate = plate
            };
        }
    }
}