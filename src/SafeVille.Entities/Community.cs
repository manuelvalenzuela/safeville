namespace SafeVille.Entities
{
    using System;

    public class Community
    {
        public Guid CommunityId { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public static Community From(Guid communityUserId, string communityName)
        {
            return new Community
            {
                CommunityId = Guid.NewGuid(),
                UserId = communityUserId,
                Name = communityName
            };
        }
    }
}