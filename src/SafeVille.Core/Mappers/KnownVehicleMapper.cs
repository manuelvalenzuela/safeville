namespace SafeVille.Core.Mappers
{
    using Dtos.Out;
    using Entities;

    public class KnownVehicleMapper
    {
        public static VehicleRegistered CreateInsertedFrom(KnownVehicle knownVehicle)
        {
            return new VehicleRegistered
            {
                KnownVehicleId = knownVehicle.KnownVehicleId
            };
        }
    }
}