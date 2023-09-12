using XFrame.Aggregates.Commands;
using XFrame.Aggregates.ExecutionResults;

namespace Globomantics.Domain.DomainModel.GlobomanticsModel.Commands
{
    public class CreateConferenceCommand
        : Command<Conference, ConferenceId>
    {
        #region Constructors

        public CreateConferenceCommand(
            ConferenceId aggregateId,
            string conferenceName,
            DateTime start,
            string location,
            int attendeeCount) 
            : base(aggregateId)
        {
            ConferenceName = conferenceName;
            Start = start;
            Location = location;
            AttendeeCount = attendeeCount;
        }

        #endregion

        #region Properties

        public string ConferenceName { get; }
        public DateTime Start { get; }
        public string Location { get; }
        public int AttendeeCount { get; }

        #endregion
    }

    public class CreateConferenceCommandCommandHandler
        : CommandHandler<Conference, ConferenceId, CreateConferenceCommand>
    {
        #region Virtual Methods

        public override Task<IExecutionResult> ExecuteAsync(
            Conference aggregate,
            CreateConferenceCommand command,
            CancellationToken cancellationToken)
        {
            aggregate.Create(
                command.ConferenceName,
                command.Start,
                command.Location,
                command.AttendeeCount);

            return Task.FromResult(ExecutionResult.Success());
        }

        #endregion
    }
}
