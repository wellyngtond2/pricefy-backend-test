using PricefyChallenge.Core.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PricefyChallenge.Core.Interfaces.Services
{
    public interface IFileServices
    {
        Task<IEnumerable<Movie>> ReadFileAsync(byte[] streamFile);
    }
}
