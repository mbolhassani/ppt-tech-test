using Api.Models;

namespace Api.Requests
{
    public interface IJSONServerRequest
    {
        Task<Image> GetImageByLastDigitOfUserIdentifierAsync(int id);
    }
}