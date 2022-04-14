using Microsoft.EntityFrameworkCore;
using PricefyChallenge.Core.Entities;
using PricefyChallenge.Core.Interfaces.Repository;
using PricefyChallenge.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricefyChallenge.Infra.Repository
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        public MovieRepository(PricefyContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Movie>> ListByDateAsync(DateTime CreateDate)
        {
            var query = _dbContext.Set<Movie>().Where(p => p.CreateDate.Date == CreateDate);

            return await query.ToListAsync();
        }

    }
}
