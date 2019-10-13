namespace SafeVille.Tests.UseCases
{
    using System;
    using Core;
    using Core.Exceptions;
    using Core.UseCases;
    using Dtos.Out;
    using FluentAssertions;
    using Mocks;
    using Xunit;

    public class ReportVehicleUseCaseTests
    {
        private const string ValidPlate = "ValidPlate";

        public ReportVehicleUseCaseTests()
        {
            Context.PlateReportedGateway = new MockPlateReportedGateway();
        }

        [Fact]
        public void ReportNullPlate_ShouldThrowException()
        {
            Func<PlateReported> action = () => ReportVehicleUseCase.Report(null);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void ReportEmptyPlate_ShouldThrowException()
        {
            Func<PlateReported> action = () => ReportVehicleUseCase.Report(string.Empty);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void ReportUnknownPlate_ShouldReturnTypeOfPlateReported()
        {
            var result = ReportVehicleUseCase.Report(ValidPlate);
            result.Should().BeOfType<PlateReported>();
        }

        [Fact]
        public void ReportUnknownPlate_ShouldNotReturnNull()
        {
            var result = ReportVehicleUseCase.Report(ValidPlate);
            result.Should().NotBeNull();
        }

        [Fact]
        public void ReportUnknownPlate_ShouldReturnPlateReportedWithNotEmptyId()
        {
            var result = ReportVehicleUseCase.Report(ValidPlate);
            result.PlateReportedId.Should().NotBeEmpty();
        }
    }
}