﻿namespace SafeVille.Core.UseCases
{
    using System;
    using System.Linq;
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

            await CheckUserBelongsToCommunityAdmins(invitation.InvitingUserId.Value, invitation.CommunityId.Value);

            return null;
        }

        private static async Task CheckUserBelongsToCommunityAdmins(Guid userId, Guid communityId)
        {
            var community = await Context.CommunityGateway.GetByIdWithAdmins(communityId);

            if (community.Administrators.All(a => a.UserId != userId))
            {
                throw new AppWithoutPermissionToPerformActionException(nameof(userId));
            }
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

        private static async Task CheckUserExists(Guid? userId)
        {
            if (userId == null || userId == Guid.Empty)
            {
                throw new AppArgumentException(nameof(userId));
            }

            if (!await Context.UserGateway.Exists(userId.Value))
            {
                throw new AppNotFoundException(nameof(userId));
            }
        }
    }
}