namespace SafeVille.Core.Gateways
{
    using System;
    using System.Threading.Tasks;

    public interface IUserGateway
    {
        Task<bool> Exists(Guid userId);
    }
}