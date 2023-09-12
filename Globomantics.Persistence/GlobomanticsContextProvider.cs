using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using XFrame.Persistence.EFCore;

namespace Globomantics.Persistence
{
    public class GlobomanticsContextProvider : IDbContextProvider<GlobomanticsContext>, IDisposable
    {
        private readonly DbContextOptions<GlobomanticsContext> _options;

        public GlobomanticsContextProvider(IConfiguration configuration)
        {
            _options = new DbContextOptionsBuilder<GlobomanticsContext>()
                .UseSqlServer(configuration["DataConnection:Database"])
                .Options;
        }

        public GlobomanticsContext CreateContext()
        {
            return new GlobomanticsContext(_options);
        }

        public void Dispose()
        {
        }
    }
}
