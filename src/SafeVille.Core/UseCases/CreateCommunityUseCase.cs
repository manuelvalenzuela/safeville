namespace SafeVille.Core.UseCases
{
    using System;
    using System.Threading.Tasks;
    using Dtos.In;
    using Dtos.Out;
    using Exceptions;
    using Mappers;

    public static class CreateCommunityUseCase
    {
        public static async Task<CommunityCreated> Create(CreateCommunityRequest community)
        {
            if (community == null)
            {
                throw new AppArgumentException(nameof(community));
            }

            if (string.IsNullOrWhiteSpace(community.Name))
            {
                throw new AppArgumentException(nameof(community.Name));
            }

            await CheckUserExists(community.UserId);

            var entity = Entities.Community.From(community.UserId.Value, community.Name);

            var created = await Context.CommunityGateway.Create(entity);

            return CommunityMapper.CreateInsertedFrom(created);
        }

        private static async Task CheckUserExists(Guid? userId)
        {
            if (userId == null || userId == Guid.Empty)
            {
                throw new AppArgumentException(nameof(userId));
            }

            if (!await Context.UserGateway.Exists(userId.Value))
            {
                throw new AppNotFoundException(nameof(userId));
            }
        }
    }
}