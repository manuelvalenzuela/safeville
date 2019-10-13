namespace SafeVille.Dtos.In
{
    using System;

    public class CreateCommunityRequest
    {
        public Guid? UserId { get; set; }

        public string Name { get; set; }
    }
}