using Globomantics.Domain.DomainModel.GlobomanticsModel;
using Globomantics.Domain.DomainModel.GlobomanticsModel.Commands;
using Globomantics.Domain.DomainModel.GlobomanticsModel.Queries;
using XFrame.Aggregates.Commands;
using XFrame.Aggregates.ExecutionResults;
using XFrame.Aggregates.Queries;
using XFrame.Common.Extensions;
using XFrame.Notifications;

namespace Globomantics.Domain.Applications
{
    public class GlobomanticsService
        : IGlobomanticsService
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryProcessor _queryProcessor;

        public GlobomanticsService(
            ICommandBus commandBus,
            IQueryProcessor queryProcessor) 
        {
            _commandBus = commandBus;
            _queryProcessor = queryProcessor;
        }

        public Task<IExecutionResult> CreateConferences(
            string conferenceName, 
            DateTime start, 
            string location, 
            int attendeeCount, 
            CancellationToken cancellationToken)
        {
            var command = new CreateConferenceCommand(
                ConferenceId.New,
                conferenceName,
                start,
                location,
                attendeeCount);

            return _commandBus
                .PublishAsync(
                    command,
                    CancellationToken.None);
        }

        public async Task<IExecutionResult> GetConference(
            ConferenceId conferenceId, 
            CancellationToken cancellationToken)
        {
            var result = await _queryProcessor.ProcessAsync(
                new GetConferenceQuery(conferenceId), cancellationToken);

            if (result.IsNotNull())
                return ExecutionResult.Success(result);

            return ExecutionResult.Failed(
                Notification.Create(
                    new Message { Text = $"No conference was found with Id {conferenceId}" }));
        }
    }
}
