namespace SafeVille.Core.Gateways
{
    using System.Threading.Tasks;
    using Entities;

    public interface ICommunityGateway
    {
        Task<Community> Create(Community community);
    }
}