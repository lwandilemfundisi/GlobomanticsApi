using Globomantics.Domain.DomainModel.GlobomanticsModel;
using XFrame.Aggregates.ExecutionResults;

namespace Globomantics.Domain.Applications
{
    public interface IGlobomanticsService
    {
        Task<IExecutionResult> GetConference(
            ConferenceId conferenceId,
            CancellationToken cancellationToken);

        Task<IExecutionResult> CreateConferences(
            string conferenceName,
            DateTime start,
            string location,
            int attendeeCount,
            CancellationToken cancellationToken);
    }
}
