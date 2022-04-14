using PricefyChallenge.Core.Dto;
using PricefyChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PricefyChallenge.Core.Interfaces.Services
{
    public interface IMovieServices
    {
        Task<IEnumerable<Movie>> GetAsync(DateTime? createDate = null);
        Task SaveAsync(FileUploadDto file);
    }
}
