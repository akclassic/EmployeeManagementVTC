using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepositoryLayer.Contracts
{
    public interface IGeneralRepository<TEntity, Tkey> 
        where TEntity : class, IEntity<Tkey>
        where Tkey: IEquatable<Tkey>
    {
        /// <summary>
        /// Find a record of entitytype with some predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Adds an entity to database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Modifies an entity in database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task EditAsync(TEntity entity);

        /// <summary>
        /// Removes an entry from database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// To Get a list of records of an entity.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntity> List(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Find an entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity FindById(Tkey id);
    }
}
