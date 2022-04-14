using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PricefyChallenge.Core.Dto;
using PricefyChallenge.Core.Interfaces.Services;
using PricefyChallenge.Core.Shared.DataContracts;
using System.IO;
using System.Threading.Tasks;

namespace PricefyChallenge.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IMovieServices _movieServices;

        public AttachmentController(IMovieServices movieServices)
        {
            _movieServices = movieServices;
        }

        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("upload-file")]
        public async Task<ActionResult<OperationResult>> UploadFile(IFormFile file)
        {
            if (file is null)
            {
                return BadRequest();
            }

            var request = new FileUploadDto(file.FileName, file.ContentType, FormFileToStream(file));

            await _movieServices.SaveAsync(request);

            return Ok(OperationResult.Success());
        }

        private static byte[] FormFileToStream(IFormFile formFile)
        {
            using var stream = new MemoryStream();

            formFile?.CopyTo(stream);

            return stream.ToArray();
        }
    }
}