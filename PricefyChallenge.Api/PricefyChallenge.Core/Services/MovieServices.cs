using Microsoft.Extensions.Logging;
using PricefyChallenge.Core.Dto;
using PricefyChallenge.Core.Entities;
using PricefyChallenge.Core.Interfaces.Repository;
using PricefyChallenge.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PricefyChallenge.Core.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IFileServices _fileServices;
        private readonly ILogger<MovieServices> _logger;
        public MovieServices(IMovieRepository movieRepository,
                             IFileServices fileServices,
                             IAttachmentRepository attachmentRepository,
                             ILogger<MovieServices> logger)
        {
            _movieRepository = movieRepository;
            _fileServices = fileServices;
            _attachmentRepository = attachmentRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Movie>> GetAsync(DateTime? createDate = null)
        {
            try
            {
                if (createDate.HasValue)
                {
                    _logger.LogInformation("Start proccess to list movie by create date.");

                    return await _movieRepository.ListByDateAsync(createDate.Value);
                }

                _logger.LogInformation("Start proccess to list movie.");

                return await _movieRepository.ListAllAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fail to try list movies");

                throw;
            }
        }

        public async Task SaveAsync(FileUploadDto file)
        {
            try
            {
                var movies = await _fileServices.ReadFileAsync(file.Data);

                if (movies.Any())
                {
                    await _attachmentRepository.AddAsync(new()
                    {
                        FileId = file.FileName,
                        Movies = movies.ToList()
                    });

                    _logger.LogInformation("Start proccess to save movie.");

                    await _movieRepository.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fail to try save movies");

                throw;
            }
        }
    }
}