namespace SafeVille.Core.Mappers
{
    using Dtos.Out;
    using Entities;

    public class CommunityMapper
    {
        public static CommunityCreated CreateInsertedFrom(Community created)
        {
            return new CommunityCreated
            {
                CommunityId = created.CommunityId
            };
        }
    }
}