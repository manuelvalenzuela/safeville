namespace SafeVille.Entities
{
    using System;

    public class Community
    {
        public Guid CommunityId { get; set; }

        public Guid OwnerId { get; set; }

        public string Name { get; set; }

        public static Community From(Guid ownerId, string communityName)
        {
            return new Community
            {
                CommunityId = Guid.NewGuid(),
                OwnerId = ownerId,
                Name = communityName
            };
        }
    }
}