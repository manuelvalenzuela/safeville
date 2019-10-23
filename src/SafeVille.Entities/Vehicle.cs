namespace SafeVille.Entities
{
    using System;

    public class Vehicle : IEntity
    {
        public Guid VehicleId { get; set; }

        public Guid UserId { get; set; }

        public string Plate { get; set; }

        public static Vehicle From(Guid userId, string plate)
        {
            return new Vehicle
            {
                VehicleId = Guid.NewGuid(),
                UserId = userId,
                Plate = plate
            };
        }
    }
}