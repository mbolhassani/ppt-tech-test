using Api.Models;

namespace Api.Repositories
{
    public interface IImageRepository
    {
        Task<Image> GetImageByIdAsync(int id);
    }
}