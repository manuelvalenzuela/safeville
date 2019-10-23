namespace SafeVille.Core.Mappers
{
    using Dtos.Out;
    using Entities;

    public class VehicleMapper
    {
        public static VehicleRegistered CreateInsertedFrom(Vehicle vehicle)
        {
            return new VehicleRegistered
            {
                VehicleId = vehicle.VehicleId
            };
        }
    }
}