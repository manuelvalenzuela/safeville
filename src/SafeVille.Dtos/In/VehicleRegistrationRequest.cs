namespace SafeVille.Dtos.In
{
    using System;

    public class VehicleRegistrationRequest
    {
        public Guid? UserId { get; set; }

        public string Plate { get; set; }
    }
}