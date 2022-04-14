using PricefyChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PricefyChallenge.Core.Interfaces.Repository
{
    public interface IMovieRepository : IRepositoryBase<Movie>
    {
        Task<IEnumerable<Movie>> ListByDateAsync(DateTime CreateDate);
    }
}
