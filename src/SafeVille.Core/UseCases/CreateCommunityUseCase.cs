using System.Threading.Tasks;
using SafeVille.Core.Mappers;

namespace SafeVille.Core.UseCases
{
    using System;
    using Dtos.In;
    using Dtos.Out;
    using Exceptions;

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
                throw new AppArgumentException(nameof(community));
            }

            if (community.UserId == null || community.UserId == Guid.Empty)
            {
                throw new AppArgumentException(nameof(community));
            }

            if (!await Context.UserGateway.Exists(community.UserId.Value))
            {
                throw new AppNotFoundException(nameof(community.UserId));
            }

            var entity = Entities.Community.From(community.UserId.Value, community.Name);

            var created = await Context.CommunityGateway.Create(entity);

            return CommunityMapper.CreateInsertedFrom(created);

        }
    }
}