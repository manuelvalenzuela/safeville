namespace SafeVille.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Vehicle : IEntity
    {
        public Guid VehicleId { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public string Plate { get; set; }

        public static Vehicle From(Guid userId, string plate) => new Vehicle
        {
            VehicleId = Guid.NewGuid(),
            UserId = userId,
            Plate = plate
        };
    }
}