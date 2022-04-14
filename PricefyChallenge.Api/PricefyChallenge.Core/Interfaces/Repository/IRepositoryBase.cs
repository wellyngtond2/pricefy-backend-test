using PricefyChallenge.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PricefyChallenge.Core.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        Task SaveChangesAsync();
        Task AddAsync(TEntity data);
        Task AddManyAsync(IEnumerable<TEntity> data);
        Task<IEnumerable<TEntity>> ListAllAsync();
    }
}
