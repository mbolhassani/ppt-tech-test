using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class SqliteDbContext: DbContext
    {
        public SqliteDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Image> Images { get; set; }
    }
}