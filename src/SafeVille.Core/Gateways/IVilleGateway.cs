namespace SafeVille.Core.Gateways
{
    public interface IVilleGateway
    {
        bool IsKnown(string plate);
    }
}