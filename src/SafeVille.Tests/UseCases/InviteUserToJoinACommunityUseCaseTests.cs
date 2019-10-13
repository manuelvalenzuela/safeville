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

    public class InviteUserToJoinACommunityUseCaseTests
    {
        private const string ExistentUserId = "ed0bf589-ac19-4adb-9199-6d6686d4b60e";
        private const string NonExistentUserId = "ab0bf589-ac19-4adb-6543-6d6686d4b60e";
        private const string ExistentNotInvitedUserId = "ef0bf589-ac19-4adb-0987-6d6686d4b60e";
        private const string ExistentCommunityId = "63875ef4-70d8-4cae-94c1-bf5ef0f6843c";
        private const string NonExistentCommunityId = "5b95dff2-40c8-4a05-bab2-345bab750b66";

        public InviteUserToJoinACommunityUseCaseTests()
        {
            Context.UserGateway = new MockUserGateway();
        }

        [Fact]
        public void InviteNull_ShouldThrowException()
        {
            Func<Task<VehicleRegistered>> action = async () => await InviteUserToJoinACommunityUseCase.Invite(null);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void InviteWithNullInvitingUserId_ShouldThrowException()
        {
            var invitation = CreateValidJoinInvitationRequest();
            invitation.InvitingUserId = null;

            Func<Task<VehicleRegistered>> action = async () => await InviteUserToJoinACommunityUseCase.Invite(invitation);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void InviteWithEmptyInvitingUserId_ShouldThrowException()
        {
            var invitation = CreateValidJoinInvitationRequest();
            invitation.InvitingUserId = Guid.Empty;

            Func<Task<VehicleRegistered>> action = async () => await InviteUserToJoinACommunityUseCase.Invite(invitation);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void InviteWithNonExistentInvitingUserId_ShouldThrowException()
        {
            var invitation = CreateValidJoinInvitationRequest();
            invitation.InvitingUserId = Guid.Parse(NonExistentUserId);

            Func<Task<VehicleRegistered>> action = async () => await InviteUserToJoinACommunityUseCase.Invite(invitation);
            action.Should().Throw<AppNotFoundException>();
        }

        private static JoinInvitationRequest CreateValidJoinInvitationRequest()
        {
            return new JoinInvitationRequest
            {
                InvitingUserId = Guid.Parse(ExistentUserId),
                InvitedUserId = Guid.Parse(ExistentNotInvitedUserId),
                CommunityId = Guid.Parse(ExistentCommunityId)
            };
        }
    }
}