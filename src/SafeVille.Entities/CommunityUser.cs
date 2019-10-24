namespace SafeVille.Entities
{
    using System;

    public class CommunityUser
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid CommunityId { get; set; }

        public Community Community { get; set; }
    }
}
