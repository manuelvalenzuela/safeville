namespace SafeVille.Core.Gateways
{
    using System;
    using System.Threading.Tasks;
    using Entities;

    public interface ICommunityGateway
    {
        Task<Community> Create(Community community);

        Task<bool> Exists(Guid communityId);

        Task<Community> GetByIdWithAdmins(Guid communityId);
    }
}