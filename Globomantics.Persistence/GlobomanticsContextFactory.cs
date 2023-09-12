﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Globomantics.Persistence
{
    public class GlobomanticsContextFactory : IDesignTimeDbContextFactory<GlobomanticsContext>
    {
        public GlobomanticsContext CreateDbContext(string[] args)
        {
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{envName}.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<GlobomanticsContext>();
            optionsBuilder.UseSqlServer(configuration["DataConnection:Database"]);

            return new GlobomanticsContext(optionsBuilder.Options);
        }
    }
}
