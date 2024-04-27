using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class SqliteRepository : IImageRepository
    {
        private readonly SqliteDbContext dbContext;
        public SqliteRepository(SqliteDbContext dbContext)
        {
            this.dbContext = dbContext;
            
        }
        public async Task<Image> GetImageByIdAsync(int id)
        {
            var image = await dbContext.Images.FirstOrDefaultAsync(i => i.Id == id);
            if (image == null)
            {
                throw new Exception("No image found.");
            } else {
                return image;
            }
        }
    }
}