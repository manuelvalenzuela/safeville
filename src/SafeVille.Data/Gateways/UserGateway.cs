namespace SafeVille.Data.Gateways
{
    using System;
    using System.Threading.Tasks;
    using Repositories;
    using SafeVille.Core.Gateways;

    public class UserGateway : IUserGateway
    {
        private readonly UserRepository _userRepository;

        public UserGateway(ApplicationContext context)
        {
            _userRepository = new UserRepository(context);
        }

        public async Task<bool> Exists(Guid userId)
        {
            var user = await _userRepository.GetById(userId).ConfigureAwait(true);
            return user != null;
        }
    }
}