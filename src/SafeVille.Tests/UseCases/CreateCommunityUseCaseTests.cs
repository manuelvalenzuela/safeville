namespace SafeVille.Tests.UseCases
{
    using System;
    using Core.Exceptions;
    using Dtos.Out;
    using FluentAssertions;
    using SafeVille.Core.UseCases;
    using Xunit;

    public class CreateCommunityUseCaseTests
    {
        [Fact]
        public void CreateNullCommunity_ShouldThrowException()
        {
            Func<CommunityCreated> action = () => CreateCommunityUseCase.Create(null);
            action.Should().Throw<AppArgumentException>();
        }
    }
}