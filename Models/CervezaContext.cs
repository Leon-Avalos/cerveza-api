using Microsoft.EntityFrameworkCore;

namespace cervezaApi.Models
{
    public class CervezaContext : DbContext
    {
        public CervezaContext(DbContextOptions<CervezaContext> options)
            : base(options)
        {
        }

        public DbSet<CervezaItems> CervezaItem { get; set; }
    }
}