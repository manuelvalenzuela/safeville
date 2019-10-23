namespace SafeVille.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    public interface IRepository<TEntity> where TEntity : IEntity
    {
        void Create(TEntity entity);

        void Delete(TEntity entity);

        void Delete(object id);

        void Edit(TEntity entity);

        Task<TEntity> GetById(object id);

        IEnumerable<TEntity> Filter();

        IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate);

        void SaveChanges();
    }
}