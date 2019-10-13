namespace SafeVille.Dtos.In
{
    using System;

    public class JoinInvitationRequest
    {
        public Guid? InvitingUserId { get; set; }

        public Guid? InvitedUserId { get; set; }

        public Guid? CommunityId { get; set; }
    }
}