using PricefyChallenge.Core.Entities;
using PricefyChallenge.Core.Interfaces.Services;
using PricefyChallenge.Infra.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PricefyChallenge.Infra.Services
{
    public class FileServices : IFileServices
    {
        public Task<IEnumerable<Movie>> ReadFileAsync(byte[] streamFile)
        {
            List<Movie> response = new();
            var count = 0;
            string line;

            using (var fs = new MemoryStream(streamFile))
            using (var reader = new StreamReader(fs))
                while ((line = reader.ReadLine()) != null)
                {
                    count++;

                    if (count == 1) continue;


                    var parts = line.Split('\t');

                    response.Add(new()
                    {
                        TConst = parts[0],
                        TitleType = parts[1],
                        PrimaryTitle = parts[2],
                        OriginalTitle = parts[3],
                        IsAdult = parts[4].ConvertToInt() == 1,
                        StartYear = parts[5].ConvertToInt() ?? 0,
                        EndYear = parts[6].ConvertToInt(),
                        RunTimeMinutes = parts[7].ConvertToInt() ?? 0,
                        Genres = parts[8],

                    });
                }


            return Task.FromResult(response.AsEnumerable());
        }
    }
}
