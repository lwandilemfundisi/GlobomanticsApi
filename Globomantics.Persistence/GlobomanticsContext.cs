using Microsoft.EntityFrameworkCore;

namespace Globomantics.Persistence
{
    public class GlobomanticsContext : DbContext
    {
        public GlobomanticsContext(DbContextOptions<GlobomanticsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.GlobomanticsModelMap();
        }
    }
}
