namespace SafeVille.Core.UseCases
{
    using System;
    using System.Threading.Tasks;
    using Dtos.In;
    using Dtos.Out;
    using Exceptions;
    using Mappers;

    public static class RegisterKnownVehicleUseCase
    {
        public static async Task<VehicleRegistered> Register(VehicleRegistrationRequest vehicleRegistrationRequest)
        {
            if (vehicleRegistrationRequest == null)
            {
                throw new AppArgumentException(nameof(vehicleRegistrationRequest));
            }

            if (vehicleRegistrationRequest.UserId == null ||
                vehicleRegistrationRequest.UserId == Guid.Empty)
            {
                throw new AppArgumentException(nameof(vehicleRegistrationRequest.UserId));
            }

            if (string.IsNullOrWhiteSpace(vehicleRegistrationRequest.Plate))
            {
                throw new AppArgumentException(nameof(vehicleRegistrationRequest.Plate));
            }

            if (!await Context.UserGateway.Exists(vehicleRegistrationRequest.UserId.Value))
            {
                throw new AppNotFoundException(nameof(vehicleRegistrationRequest.UserId));
            }

            var entity = Entities.Vehicle.From(vehicleRegistrationRequest.UserId.Value, vehicleRegistrationRequest.Plate);

            var created = await Context.VehicleGateway.RegisterKnownVehicle(entity);

            return VehicleMapper.CreateInsertedFrom(created);
        }
    }
}