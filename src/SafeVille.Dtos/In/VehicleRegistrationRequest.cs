namespace SafeVille.Dtos.In
{
    using System;

    public class VehicleRegistrationRequest
    {
        public Guid? AccountableUserId { get; set; }

        public string Plate { get; set; }
    }
}