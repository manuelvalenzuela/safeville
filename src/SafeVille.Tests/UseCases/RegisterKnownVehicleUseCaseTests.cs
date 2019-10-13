namespace SafeVille.Tests.UseCases
{
    using System;
    using System.Threading.Tasks;
    using Core;
    using Core.Exceptions;
    using Dtos.In;
    using Dtos.Out;
    using FluentAssertions;
    using Mocks;
    using SafeVille.Core.UseCases;
    using Xunit;

    public class RegisterKnownVehicleUseCaseTests
    {
        private const string ExistentUserId = "ed0bf589-ac19-4adb-9199-6d6686d4b60e";
        private const string NonExistentUserId = "ab0bf589-ac19-4adb-6543-6d6686d4b60e";
        private const string ValidPlate = "VALID_PLATE";

        public RegisterKnownVehicleUseCaseTests()
        {
            Context.UserGateway = new MockUserGateway();
        }

        [Fact]
        public void RegisterNullVehicle_ShouldThrowException()
        {
            Func<Task<VehicleRegistered>> action = async () => await RegisterKnownVehicleUseCase.Register(null);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void RegisterVehicleWithNullAccountableUserId_ShouldThrowException()
        {
            var vehicleRegistrationRequest = CreateValidVehicleRegistrationRequest();
            vehicleRegistrationRequest.AccountableUserId = null;

            Func<Task<VehicleRegistered>> action = async () => await RegisterKnownVehicleUseCase.Register(vehicleRegistrationRequest);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void RegisterVehicleWithEmptyAccountableUserId_ShouldThrowException()
        {
            var vehicleRegistrationRequest = CreateValidVehicleRegistrationRequest();
            vehicleRegistrationRequest.AccountableUserId = Guid.Empty;

            Func<Task<VehicleRegistered>> action = async () => await RegisterKnownVehicleUseCase.Register(vehicleRegistrationRequest);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void RegisterVehicleWithNonExistentAccountableUserId_ShouldThrowException()
        {
            var vehicleRegistrationRequest = CreateValidVehicleRegistrationRequest();
            vehicleRegistrationRequest.AccountableUserId = Guid.Parse(NonExistentUserId);

            Func<Task<VehicleRegistered>> action = async () => await RegisterKnownVehicleUseCase.Register(vehicleRegistrationRequest);
            action.Should().Throw<AppNotFoundException>();
        }

        [Fact]
        public void RegisterVehicleWithNullPlate_ShouldThrowException()
        {
            var vehicleRegistrationRequest = CreateValidVehicleRegistrationRequest();
            vehicleRegistrationRequest.Plate = null;

            Func<Task<VehicleRegistered>> action = async () => await RegisterKnownVehicleUseCase.Register(vehicleRegistrationRequest);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void RegisterVehicleWithEmptyPlate_ShouldThrowException()
        {
            var vehicleRegistrationRequest = CreateValidVehicleRegistrationRequest();
            vehicleRegistrationRequest.Plate = string.Empty;

            Func<Task<VehicleRegistered>> action = async () => await RegisterKnownVehicleUseCase.Register(vehicleRegistrationRequest);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public async void RegisterValidKnownVehicle_ShouldReturnOfTypeVehicleRegistered()
        {
            var vehicleRegistrationRequest = CreateValidVehicleRegistrationRequest();

            var registration = await RegisterKnownVehicleUseCase.Register(vehicleRegistrationRequest);
            registration.Should().BeOfType<VehicleRegistered>();
        }

        [Fact]
        public async void RegisterValidKnownVehicle_ShouldReturnObjectThatHavePropertyKnownVehicleId()
        {
            var vehicleRegistrationRequest = CreateValidVehicleRegistrationRequest();
            var registration = await RegisterKnownVehicleUseCase.Register(vehicleRegistrationRequest);
            var properties = registration.GetType().GetProperties();
            properties.Should().Contain(p => p.Name == "KnownVehicleId");
        }

        [Fact]
        public async void RegisterValidKnownVehicle_ShouldReturnObjectThatHaveNotEmptyKnownVehicleId()
        {
            var vehicleRegistrationRequest = CreateValidVehicleRegistrationRequest();
            var registration = await RegisterKnownVehicleUseCase.Register(vehicleRegistrationRequest);
            registration.KnownVehicleId.Should().NotBeEmpty();
        }

        private static VehicleRegistrationRequest CreateValidVehicleRegistrationRequest()
        {
            return new VehicleRegistrationRequest
            {
                AccountableUserId = Guid.Parse(ExistentUserId),
                Plate = ValidPlate
            };
        }
    }
}