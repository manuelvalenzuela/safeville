namespace SafeVille.Data.Repositories
{
    using Entities;

    public class UserRepository : Repository<User>
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}