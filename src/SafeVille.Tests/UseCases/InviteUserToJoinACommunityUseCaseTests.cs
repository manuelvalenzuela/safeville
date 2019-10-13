namespace SafeVille.Tests.UseCases
{
    using System;
    using System.Threading.Tasks;
    using Core.Exceptions;
    using Dtos.Out;
    using FluentAssertions;
    using SafeVille.Core.UseCases;
    using Xunit;

    public class InviteUserToJoinACommunityUseCaseTests
    {
        [Fact]
        public void InviteNull_ShouldThrowException()
        {
            Func<Task<VehicleRegistered>> action = async () => await InviteUserToJoinACommunityUseCase.Invite(null);
            action.Should().Throw<AppArgumentException>();
        }
    }
}