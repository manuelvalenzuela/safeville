namespace SafeVille.Entities
{
    using System;
    using System.Collections.Generic;

    public class Community : IEntity
    {
        public Guid CommunityId { get; set; }

        public Guid OwnerId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CommunityUser> CommunityUsers { get; set; }

        public static Community From(Guid ownerId, string communityName) => new Community
        {
            CommunityId = Guid.NewGuid(),
            OwnerId = ownerId,
            Name = communityName,
            CommunityUsers = new List<CommunityUser>()
        };
    }
}