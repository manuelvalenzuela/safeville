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

            if (vehicleRegistrationRequest.AccountableUserId == null ||
                vehicleRegistrationRequest.AccountableUserId == Guid.Empty)
            {
                throw new AppArgumentException(nameof(vehicleRegistrationRequest.AccountableUserId));
            }

            if (string.IsNullOrWhiteSpace(vehicleRegistrationRequest.Plate))
            {
                throw new AppArgumentException(nameof(vehicleRegistrationRequest.Plate));
            }

            if (!await Context.UserGateway.Exists(vehicleRegistrationRequest.AccountableUserId.Value))
            {
                throw new AppNotFoundException(nameof(vehicleRegistrationRequest.AccountableUserId));
            }

            var entity = Entities.KnownVehicle.From(vehicleRegistrationRequest.AccountableUserId.Value, vehicleRegistrationRequest.Plate);

            var created = await Context.UserGateway.RegisterKnownVehicle(entity);

            return KnownVehicleMapper.CreateInsertedFrom(created);
        }
    }
}