namespace SafeVille.Data.Gateways
{
    using System;
    using System.Threading.Tasks;
    using Entities;
    using Repositories;
    using SafeVille.Core.Gateways;

    public class CommunityGateway : ICommunityGateway
    {
        private readonly CommunityRepository _communityRepository;

        public CommunityGateway(ApplicationContext context)
        {
            _communityRepository = new CommunityRepository(context);
        }

        public async Task<Community> Create(Community community)
        {
            _communityRepository.Create(community);
            _communityRepository.SaveChanges();
            return await Task.FromResult(community)
                .ConfigureAwait(true);
        }

        public async Task<bool> Exists(Guid communityId)
        {
            var community = await _communityRepository.GetById(communityId)
                .ConfigureAwait(true);
            return community != null;
        }

        public async Task<Community> GetByIdWithAdmins(Guid communityId)
        {
            return await _communityRepository.GetByIdWithAdmins(communityId)
                .ConfigureAwait(true);
        }
    }
}