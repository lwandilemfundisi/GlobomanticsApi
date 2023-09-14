using Globomantics.Domain.DomainModel.GlobomanticsModel.Events;
using XFrame.AggregateEventPublisher;
using XFrame.Aggregates.Events;

namespace Globomantics.Domain.DomainModel.GlobomanticsModel.Subscribers
{
    public class CreatedConferenceEventSubscriber
        : ISubscribeAsynchronousTo<Conference, ConferenceId, CreatedConferenceEvent>
    {
        public Task HandleAsync(
            IDomainEvent<Conference, ConferenceId, CreatedConferenceEvent> domainEvent,
            CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
