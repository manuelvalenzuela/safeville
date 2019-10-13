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

    public class CreateCommunityUseCaseTests
    {
        private const string ExistentUserId = "ed0bf589-ac19-4adb-9199-6d6686d4b60e";
        private const string NonExistentUserId = "ab0bf589-ac19-4adb-6543-6d6686d4b60e";
        private const string ValidCommunityName = "Valid Community Name";

        public CreateCommunityUseCaseTests()
        {
            Context.UserGateway = new MockUserGateway();
            Context.CommunityGateway = new MockCommunityGateway();
        }

        [Fact]
        public void CreateNullCommunity_ShouldThrowException()
        {
            Func<Task<CommunityCreated>> action = async () => await CreateCommunityUseCase.Create(null);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void CreateCommunityWithNullUserId_ShouldThrowException()
        {
            var createCommunityRequest = CreateValidCommunityRequest();
            createCommunityRequest.UserId = null;

            Func<Task<CommunityCreated>> action = () => CreateCommunityUseCase.Create(createCommunityRequest);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void CreateCommunityWithEmptyUserId_ShouldThrowException()
        {
            var createCommunityRequest = CreateValidCommunityRequest();
            createCommunityRequest.UserId = Guid.Empty;

            Func<Task<CommunityCreated>> action = () => CreateCommunityUseCase.Create(createCommunityRequest);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void CreateCommunityWithNonExistentUserId_ShouldThrowException()
        {
            var createCommunityRequest = CreateValidCommunityRequest();
            createCommunityRequest.UserId = Guid.Parse(NonExistentUserId);

            Func<Task<CommunityCreated>> action = () => CreateCommunityUseCase.Create(createCommunityRequest);
            action.Should().Throw<AppNotFoundException>();
        }

        [Fact]
        public void CreateCommunityWithEmptyName_ShouldThrowException()
        {
            var createCommunityRequest = CreateValidCommunityRequest();
            createCommunityRequest.Name = string.Empty;

            Func<Task<CommunityCreated>> action = () => CreateCommunityUseCase.Create(createCommunityRequest);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public async void CreateValidCommunityRequest_ShouldReturnOfTypeCommunityCreated()
        {
            var createCommunityRequest = CreateValidCommunityRequest();
            var created = await CreateCommunityUseCase.Create(createCommunityRequest);
            created.Should().BeOfType<CommunityCreated>();
        }

        [Fact]
        public async void CreateValidCommunityRequest_ShouldReturnObjectThatHavePropertyCommunityId()
        {
            var createCommunityRequest = CreateValidCommunityRequest();
            var created = await CreateCommunityUseCase.Create(createCommunityRequest);
            var properties = created.GetType().GetProperties();
            properties.Should().Contain(p => p.Name == "CommunityId");
        }

        [Fact]
        public async void CreateValidCommunityRequest_ShouldReturnObjectThatHaveNotEmptyCommunityId()
        {
            var createCommunityRequest = CreateValidCommunityRequest();
            var created = await CreateCommunityUseCase.Create(createCommunityRequest);
            created.CommunityId.Should().NotBeEmpty();
        }

        private static CreateCommunityRequest CreateValidCommunityRequest()
        {
            return new CreateCommunityRequest
            {
                UserId = Guid.Parse(ExistentUserId),
                Name = ValidCommunityName
            };
        }
    }
}