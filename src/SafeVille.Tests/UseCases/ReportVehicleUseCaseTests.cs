namespace SafeVille.Tests.UseCases
{
    using System;
    using System.Threading.Tasks;
    using Core;
    using Core.Exceptions;
    using Core.UseCases;
    using Dtos.In;
    using Dtos.Out;
    using FluentAssertions;
    using Mocks;
    using Xunit;

    public class ReportVehicleUseCaseTests
    {
        private const string ValidPlate = "ValidPlate";
        private const string ExistentCommunityId = "63875ef4-70d8-4cae-94c1-bf5ef0f6843c";
        private const string ExistentUserId = "ed0bf589-ac19-4adb-9199-6d6686d4b60e";

        public ReportVehicleUseCaseTests()
        {
            Context.VehicleReportGateway = new MockVehicleReportGateway();
        }

        [Fact]
        public void ReportNullPlateRequest_ShouldThrowException()
        {
            Func<Task<VehicleReport>> action = async () => await ReportVehicleUseCase.Report(null);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void ReportNullPlate_ShouldThrowException()
        {
            var vehicleToReport = CreateValidVehicleReport();
            vehicleToReport.Plate = null;
            Func<Task<VehicleReport>> action = async () => await ReportVehicleUseCase.Report(vehicleToReport);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void ReportEmptyPlate_ShouldThrowException()
        {
            var vehicleToReport = CreateValidVehicleReport();
            vehicleToReport.Plate = string.Empty;
            Func<Task<VehicleReport>> action = async () => await ReportVehicleUseCase.Report(vehicleToReport);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void ReportWithNullCommunityId_ShouldThrowException()
        {
            var vehicleToReport = CreateValidVehicleReport();
            vehicleToReport.CommunityId = null;
            Func<Task<VehicleReport>> action = async () => await ReportVehicleUseCase.Report(vehicleToReport);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void ReportWithEmptyCommunityId_ShouldThrowException()
        {
            var vehicleToReport = CreateValidVehicleReport();
            vehicleToReport.CommunityId = Guid.Empty;
            Func<Task<VehicleReport>> action = async () => await ReportVehicleUseCase.Report(vehicleToReport);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void ReportWithNullUserId_ShouldThrowException()
        {
            var vehicleToReport = CreateValidVehicleReport();
            vehicleToReport.UserId = null;
            Func<Task<VehicleReport>> action = async () => await ReportVehicleUseCase.Report(vehicleToReport);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void ReportWithEmptyUserId_ShouldThrowException()
        {
            var vehicleToReport = CreateValidVehicleReport();
            vehicleToReport.UserId = Guid.Empty;
            Func<Task<VehicleReport>> action = async () => await ReportVehicleUseCase.Report(vehicleToReport);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public async Task ReportUnknownPlate_ShouldReturnTypeOfPlateReport()
        {
            var vehicleToReport = CreateValidVehicleReport();
            var result = await ReportVehicleUseCase.Report(vehicleToReport);
            result.Should().BeOfType<VehicleReport>();
        }

        [Fact]
        public async Task ReportUnknownPlate_ShouldNotReturnNull()
        {
            var vehicleToReport = CreateValidVehicleReport();
            var result = await ReportVehicleUseCase.Report(vehicleToReport);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task ReportUnknownPlate_ShouldReturnPlateReportWithNotEmptyId()
        {
            var vehicleToReport = CreateValidVehicleReport();
            var result = await ReportVehicleUseCase.Report(vehicleToReport);
            result.VehicleReportId.Should().NotBeEmpty();
        }

        private static ReportVehicleRequest CreateValidVehicleReport()
        {
            return new ReportVehicleRequest
            {
                Plate = ValidPlate,
                CommunityId = Guid.Parse(ExistentCommunityId),
                UserId = Guid.Parse(ExistentUserId)
            };
        }
    }
}