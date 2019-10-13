namespace SafeVille.Core.UseCases
{
    using System;
    using System.Collections.Generic;
    using System.Text;
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

            if (invitation.InvitingUserId == null || invitation.InvitingUserId == Guid.Empty)
            {
                throw new AppArgumentException(nameof(invitation.InvitingUserId));
            }

            if (!await Context.UserGateway.Exists(invitation.InvitingUserId.Value))
            {
                throw new AppNotFoundException(nameof(invitation.InvitingUserId));
            }

            return null;
        }
    }
}