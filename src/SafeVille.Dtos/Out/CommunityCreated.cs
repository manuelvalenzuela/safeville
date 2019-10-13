namespace SafeVille.Dtos.Out
{
    using System;

    public class CommunityCreated
    {
        public Guid CommunityId { get; set; }

        public Guid AdminUserId { get; set; }

        public string Name { get; set; }
    }
}