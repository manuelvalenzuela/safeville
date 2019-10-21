namespace SafeVille.Tests.UseCases
{
    using System;
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

        public ReportVehicleUseCaseTests()
        {
            Context.PlateReportedGateway = new MockPlateReportedGateway();
        }

        [Fact]
        public void ReportNullPlateRequest_ShouldThrowException()
        {
            Func<PlateReported> action = () => ReportVehicleUseCase.Report(null);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void ReportNullPlate_ShouldThrowException()
        {
            var vehicleToReport = CreateValidVehicleReport();
            vehicleToReport.Plate = null;
            Func<PlateReported> action = () => ReportVehicleUseCase.Report(vehicleToReport);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void ReportEmptyPlate_ShouldThrowException()
        {
            var vehicleToReport = CreateValidVehicleReport();
            vehicleToReport.Plate = string.Empty;
            Func<PlateReported> action = () => ReportVehicleUseCase.Report(vehicleToReport);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void ReportWithNullCommunityId_ShouldThrowException()
        {
            var vehicleToReport = CreateValidVehicleReport();
            vehicleToReport.CommunityId = null;
            Func<PlateReported> action = () => ReportVehicleUseCase.Report(vehicleToReport);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void ReportWithEmptyCommunityId_ShouldThrowException()
        {
            var vehicleToReport = CreateValidVehicleReport();
            vehicleToReport.CommunityId = Guid.Empty;
            Func<PlateReported> action = () => ReportVehicleUseCase.Report(vehicleToReport);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void ReportUnknownPlate_ShouldReturnTypeOfPlateReported()
        {
            var vehicleToReport = CreateValidVehicleReport();
            var result = ReportVehicleUseCase.Report(vehicleToReport);
            result.Should().BeOfType<PlateReported>();
        }

        [Fact]
        public void ReportUnknownPlate_ShouldNotReturnNull()
        {
            var vehicleToReport = CreateValidVehicleReport();
            var result = ReportVehicleUseCase.Report(vehicleToReport);
            result.Should().NotBeNull();
        }

        [Fact]
        public void ReportUnknownPlate_ShouldReturnPlateReportedWithNotEmptyId()
        {
            var vehicleToReport = CreateValidVehicleReport();
            var result = ReportVehicleUseCase.Report(vehicleToReport);
            result.PlateReportedId.Should().NotBeEmpty();
        }

        private static ReportVehicleRequest CreateValidVehicleReport()
        {
            return new ReportVehicleRequest
            {
                Plate = ValidPlate,
                CommunityId = Guid.Parse(ExistentCommunityId)
            };
        }
    }
}