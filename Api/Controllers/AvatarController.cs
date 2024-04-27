using Api.Models;
using Api.Services.ImageService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvatarController : ControllerBase
    {
        private readonly ILogger<AvatarController> _logger;
        private readonly IImageService _imageService;

        public AvatarController(ILogger<AvatarController> logger, IImageService imageService)
        {
            _logger = logger;
            _imageService = imageService;
        }

        [HttpGet(Name = "GetImageUrl")]
        public async Task<ActionResult<ServiceResponse<string>>> Get([FromQuery(Name = "userIdentifier")] string userIdentifier)
        {
            return Ok(await _imageService.GetImageUrl(userIdentifier));
        }
    }
}