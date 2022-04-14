using Microsoft.EntityFrameworkCore;
using PricefyChallenge.Core.Entities;
using PricefyChallenge.Core.Interfaces.Repository;
using PricefyChallenge.Infra.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PricefyChallenge.Infra.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected PricefyContext _dbContext;
        public RepositoryBase(PricefyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TEntity data)
        {
            await _dbContext.Set<TEntity>().AddAsync(data);
        }

        public async Task AddManyAsync(IEnumerable<TEntity> data)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(data);
        }

        public async Task<IEnumerable<TEntity>> ListAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
