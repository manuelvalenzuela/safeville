namespace SafeVille.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public Repository(ApplicationContext context) => Context = context;

        protected ApplicationContext Context { get; }

        public void Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public async void Delete(object id)
        {
            var entityToDelete = await Context.Set<TEntity>().FindAsync(id).ConfigureAwait(true);
            if (entityToDelete != null)
            {
                Context.Set<TEntity>().Remove(entityToDelete);
            }
        }

        public void Edit(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public async Task<TEntity> GetById(object id)
        {
            return await Context.Set<TEntity>().FindAsync(id).ConfigureAwait(true);
        }

        public IEnumerable<TEntity> Filter()
        {
            return Context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void SaveChanges() => Context.SaveChanges();
    }
}