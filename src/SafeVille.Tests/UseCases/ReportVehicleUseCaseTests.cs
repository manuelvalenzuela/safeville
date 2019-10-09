namespace SafeVille.Tests.UseCases
{
    using System;
    using Core;
    using Core.Exceptions;
    using Core.Gateways;
    using Core.UseCases;
    using Dtos.Out;
    using FluentAssertions;
    using Mocks;
    using Moq;
    using Xunit;

    public class ReportVehicleUseCaseTests
    {
        private const string UnknownPlate = "UnknownPlate";
        private const string KnownPlate = "KnownPlate";
        private readonly ReportVehicleUseCase _useCase;
        private readonly Mock<IPlateReportedGateway> _mockPlateReportedGateway;
        private readonly Mock<IVilleGateway> _mockVilleGateway;

        public ReportVehicleUseCaseTests()
        {
            _mockPlateReportedGateway = new Mock<IPlateReportedGateway>();
            _mockVilleGateway = new Mock<IVilleGateway>();
            Context.PlateReportedGateway = _mockPlateReportedGateway.Object;
            Context.VilleGateway = _mockVilleGateway.Object;
            _useCase = new ReportVehicleUseCase();
        }

        [Fact]
        public void NotNullTest()
        {
            _useCase.Should().NotBeNull();
        }

        [Fact]
        public void ReportNullPlate_ShouldThrowException()
        {
            Func<PlateReported> action = () => _useCase.Report(null);

            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void ReportEmptyPlate_ShouldThrowException()
        {
            Func<PlateReported> action = () => _useCase.Report(string.Empty);

            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void ReportUnknownPlate_ShouldReturnExpected()
        {
            var result = _useCase.Report(UnknownPlate);
            result.Should().BeOfType<PlateReported>();
            result.PlateReportedId.Should().NotBeEmpty();
            _mockVilleGateway.Verify(v => v.IsKnown(UnknownPlate), Times.Once);
        }
    }
}