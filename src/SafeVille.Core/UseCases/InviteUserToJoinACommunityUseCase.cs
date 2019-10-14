namespace SafeVille.Core.UseCases
{
    using System;
    using System.Threading.Tasks;
    using Dtos.In;
    using Dtos.Out;
    using Exceptions;

    public static class InviteUserToJoinACommunityUseCase
    {
        public static async Task<VehicleRegistered> Invite(JoinInvitationRequest invitation)
        {
            if (invitation == null)
            {
                throw new AppArgumentException(nameof(invitation));
            }

            await CheckUserExists(invitation.InvitingUserId);

            await CheckCommunityExists(invitation.CommunityId);

            await CheckUserExists(invitation.InvitedUserId);

            return null;
        }

        private static async Task CheckCommunityExists(Guid? communityId)
        {
            if (communityId == null || communityId == Guid.Empty)
            {
                throw new AppArgumentException(nameof(communityId));
            }

            if (!await Context.CommunityGateway.Exists(communityId.Value))
            {
                throw new AppNotFoundException(nameof(communityId));
            }
        }

        private static async Task CheckUserExists(Guid? invitingUserId)
        {
            if (invitingUserId == null || invitingUserId == Guid.Empty)
            {
                throw new AppArgumentException(nameof(invitingUserId));
            }

            if (!await Context.UserGateway.Exists(invitingUserId.Value))
            {
                throw new AppNotFoundException(nameof(invitingUserId));
            }
        }
    }
}