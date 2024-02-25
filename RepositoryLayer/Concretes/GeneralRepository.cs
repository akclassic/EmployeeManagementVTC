using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Contracts;

namespace RepositoryLayer.Concretes
{
    public class GeneralRepository<TEntity, Tkey> : IGeneralRepository<TEntity, Tkey>
        where TEntity : class, IEntity<Tkey>
        where Tkey : IEquatable<Tkey>
    {
        private readonly EmployeeManagementDbContext _dbContext;
        public GeneralRepository(EmployeeManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task EditAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public TEntity FindById(Tkey id)
        {
            return _dbContext.Set<TEntity>().FirstOrDefault(entity => entity.Id.Equals(id));
        }

        public IQueryable<TEntity> List(Expression<Func<TEntity, bool>> predicate = null)
        {
            Expression<Func<TEntity, bool>> conditions = predicate != null ? predicate : (p) => true;

            IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable().AsNoTracking();
            
            return query.Where(conditions);
        }
    }
}
