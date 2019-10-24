namespace SafeVille.Entities
{
    using System;
    using System.Collections.Generic;

    public class User : IEntity
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }
     
        public string Lastname { get; set; }

        public virtual ICollection<CommunityUser> UserCommunities { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}