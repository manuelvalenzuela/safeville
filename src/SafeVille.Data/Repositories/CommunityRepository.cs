namespace SafeVille.Data.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class CommunityRepository : Repository<Community>
    {
        public CommunityRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Community> GetByIdWithAdmins(Guid communityId)
        {
            return await Context.Communities
                .Include(c => c.CommunityUsers)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(c => c.CommunityId == communityId)
                .ConfigureAwait(true);
        }
    }
}