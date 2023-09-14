using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using XFrame.AggregateEventPublisher;
using XFrame.AggregateEventPublisher.Extensions;
using XFrame.Aggregates.Commands.Extensions;
using XFrame.Aggregates.EventMetadata.Extentions;
using XFrame.Aggregates.Events.Extensions;
using XFrame.Aggregates.Queries.Extensions;
using XFrame.DomainContainers;
using XFrame.Jobs.Extensions;

namespace Globomantics.Domain.Extensions
{
    public static class GlobomanticsDomainExtensions
    {
        public static Assembly Assembly { get; } =
            typeof(GlobomanticsDomainExtensions).Assembly;

        public static IDomainContainer ConfigureGlobomanticsDomain(
            this IServiceCollection services,
            IConfiguration configuration = null)
        {
            return DomainContainer.New(services)
                .AddEvents(Assembly, null)
                .AddCommands(Assembly, null)
                .AddCommandHandlers(Assembly, null)
                .AddMetadataProviders(Assembly, null)
                .AddSubscribers(Assembly, null)
                .AddQueryHandlers(Assembly, null)
                .AddJobs(typeof(DispatchToAsynchronousEventSubscribersJob));
        }
    }
}
