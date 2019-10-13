namespace SafeVille.Core.Gateways
{
    using System;
    using System.Threading.Tasks;
    using Entities;

    public interface IUserGateway
    {
        Task<bool> Exists(Guid userId);

        Task<KnownVehicle> RegisterKnownVehicle(KnownVehicle knownVehicle);
    }
}