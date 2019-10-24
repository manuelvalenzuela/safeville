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
        private const string ExistentUserIdThatDontBelongToCommunityAdmins = "473e95d1-338d-4776-af44-1a346c19b8c6";

        public InviteUserToJoinACommunityUseCaseTests()
        {
            Context.UserGateway = new MockUserGateway();
            Context.CommunityGateway = new MockCommunityGateway();
        }

        [Fact]
        public void InviteNull_ShouldThrowException()
        {
            Func<Task<InvitationSent>> action = async () => await InviteUserToJoinACommunityUseCase.Invite(null);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void InviteWithNullInvitingUserId_ShouldThrowException()
        {
            var invitation = CreateValidJoinInvitationRequest();
            invitation.InvitingUserId = null;

            Func<Task<InvitationSent>> action = async () => await InviteUserToJoinACommunityUseCase.Invite(invitation);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void InviteWithEmptyInvitingUserId_ShouldThrowException()
        {
            var invitation = CreateValidJoinInvitationRequest();
            invitation.InvitingUserId = Guid.Empty;

            Func<Task<InvitationSent>> action = async () => await InviteUserToJoinACommunityUseCase.Invite(invitation);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void InviteWithNonExistentInvitingUserId_ShouldThrowException()
        {
            var invitation = CreateValidJoinInvitationRequest();
            invitation.InvitingUserId = Guid.Parse(NonExistentUserId);

            Func<Task<InvitationSent>> action = async () => await InviteUserToJoinACommunityUseCase.Invite(invitation);
            action.Should().Throw<AppNotFoundException>();
        }

        [Fact]
        public void InviteWithNullCommunityId_ShouldThrowException()
        {
            var invitation = CreateValidJoinInvitationRequest();
            invitation.CommunityId = null;

            Func<Task<InvitationSent>> action = async () => await InviteUserToJoinACommunityUseCase.Invite(invitation);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void InviteWithEmptyCommunityId_ShouldThrowException()
        {
            var invitation = CreateValidJoinInvitationRequest();
            invitation.CommunityId = Guid.Empty;

            Func<Task<InvitationSent>> action = async () => await InviteUserToJoinACommunityUseCase.Invite(invitation);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void InviteWithNonExistentCommunityId_ShouldThrowException()
        {
            var invitation = CreateValidJoinInvitationRequest();
            invitation.CommunityId = Guid.Parse(NonExistentCommunityId);

            Func<Task<InvitationSent>> action = async () => await InviteUserToJoinACommunityUseCase.Invite(invitation);
            action.Should().Throw<AppNotFoundException>();
        }

        [Fact]
        public void InviteWithNullInvitedUserId_ShouldThrowException()
        {
            var invitation = CreateValidJoinInvitationRequest();
            invitation.InvitedUserId = null;

            Func<Task<InvitationSent>> action = async () => await InviteUserToJoinACommunityUseCase.Invite(invitation);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void InviteWithEmptyInvitedUserId_ShouldThrowException()
        {
            var invitation = CreateValidJoinInvitationRequest();
            invitation.InvitedUserId = Guid.Empty;

            Func<Task<InvitationSent>> action = async () => await InviteUserToJoinACommunityUseCase.Invite(invitation);
            action.Should().Throw<AppArgumentException>();
        }

        [Fact]
        public void InviteWithNonExistentInvitedUserId_ShouldThrowException()
        {
            var invitation = CreateValidJoinInvitationRequest();
            invitation.InvitedUserId = Guid.Parse(NonExistentUserId);

            Func<Task<InvitationSent>> action = async () => await InviteUserToJoinACommunityUseCase.Invite(invitation);
            action.Should().Throw<AppNotFoundException>();
        }

        [Fact]
        public void InviteWith_InvitingUserId_ThatDontBelongToCommunityAdmins_ShouldThrowException()
        {
            var invitation = CreateValidJoinInvitationRequest();
            invitation.InvitingUserId = Guid.Parse(ExistentUserIdThatDontBelongToCommunityAdmins);

            Func<Task<InvitationSent>> action = async () => await InviteUserToJoinACommunityUseCase.Invite(invitation);
            action.Should().Throw<AppWithoutPermissionToPerformActionException>();
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