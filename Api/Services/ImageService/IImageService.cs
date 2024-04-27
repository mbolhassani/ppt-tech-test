using Api.Models;

namespace Api.Services.ImageService
{
    public interface IImageService
    {
        Task<ServiceResponse<string>> GetImageUrl(string userIdentifier);
    }
}