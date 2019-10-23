namespace SafeVille.Entities
{
    using System;
    using System.Collections.Generic;

    public class Community : IEntity
    {
        public Guid CommunityId { get; set; }

        public Guid OwnerId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Administrators { get; set; }

        public static Community From(Guid ownerId, string communityName)
        {
            return new Community
            {
                CommunityId = Guid.NewGuid(),
                OwnerId = ownerId,
                Name = communityName,
                Administrators = new List<User>()
            };
        }
    }
}