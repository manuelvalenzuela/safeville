namespace SafeVille.Entities
{
    using System;

    public class User : IEntity
    {
        public Guid UserId { get; set; }
    }
}